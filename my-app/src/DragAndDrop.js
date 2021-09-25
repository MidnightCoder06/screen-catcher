// handle file uploads in React using the HTML drag-and-drop API. 
import React from 'react';
import './DragAndDrop.css';

/*
State Management

To handle states, React provides the useState and useReducer hooks. 
We’ll opt for the useReducer hook given that we will be dealing with situations where a state depends on the previous state.
The useReducer hook accepts a reducer of type (state, action) => newState, and returns the current state paired with a dispatch method.
https://reactjs.org/docs/hooks-reference.html#usereducer

The useReducer hook accepts two arguments: a reducer and an initial state. 
It returns the current state and a dispatch function with which to update the state. 
The state is updated by dispatching an action that contains a type and an optional payload. 
The update made to the component’s state is dependent on what is returned from the case statement as a result of the action type. 
(Note here that our initial state is an object.)

For each of the state variables, we defined a corresponding case statement to update it. 
The update is performed by invoking the dispatch function returned by useReducer.
*/

const DragAndDrop = props => {
    /*
    Each of these handler function receives the event object as its argument.
    For each of the event handlers, we call preventDefault() to stop the browser from executing its default behavior. 
    The default browser behavior is to open the dropped file. 
    We also call stopPropagation() to make sure that the event is not propagated from child to parent elements.
    */

    const { data, dispatch } = props;

    const handleDragEnter = e => {
        e.preventDefault();
        e.stopPropagation();
        console.log('Enter ');
        dispatch({ type: 'SET_DROP_DEPTH', dropDepth: data.dropDepth + 1 });
    };

    const handleDragLeave = e => {
        e.preventDefault();
        e.stopPropagation();
        console.log('Leave');
        dispatch({ type: 'SET_DROP_DEPTH', dropDepth: data.dropDepth - 1 });
        if (data.dropDepth > 0) return
        dispatch({ type: 'SET_IN_DROP_ZONE', inDropZone: false })
    };

    const handleDragOver = e => {
        e.preventDefault();
        e.stopPropagation();
        console.log('Over');
        e.dataTransfer.dropEffect = 'copy'; // On a Mac, having set the dropEffect on the dataTransfer object to copy has the effect of showing a green plus sign as you drag an item around in the drop zone.
        dispatch({ type: 'SET_IN_DROP_ZONE', inDropZone: true });
    };

    const handleDrop = e => {
        e.preventDefault();
        e.stopPropagation();
        console.log('Drop');
        let files = [...e.dataTransfer.files];
  
        if (files && files.length > 0) {
            const existingFiles = data.fileList.map(f => f.name)
            files = files.filter(f => !existingFiles.includes(f.name))
            
            dispatch({ type: 'ADD_FILE_TO_LIST', files });
            e.dataTransfer.clearData();
            dispatch({ type: 'SET_DROP_DEPTH', dropDepth: 0 });
            dispatch({ type: 'SET_IN_DROP_ZONE', inDropZone: false });
        }
        /*
        We can access the dropped files with e.dataTransfer.files. 
        The value is an array-like object so we use the array spread syntax to convert it to a JavaScript array.
        We now need to check if there is at least one file before attempting to add it to our array of files. 
        We also make sure to not include files that are already on our fileList. 
        The dataTransfer object is cleared in preparation for the next drag-and-drop operation. 
        We also reset the values of dropDepth and inDropZone.
        */
        
    };

    
    
    

  return (
    <div className={data.inDropZone ? 'drag-drop-zone inside-drag-area' : 'drag-drop-zone'}
      onDrop={e => handleDrop(e)}
      onDragOver={e => handleDragOver(e)}
      onDragEnter={e => handleDragEnter(e)}
      onDragLeave={e => handleDragLeave(e)}
    >
      <p>Drag files here to upload</p>
      
    </div>
  );
};

export default DragAndDrop;
