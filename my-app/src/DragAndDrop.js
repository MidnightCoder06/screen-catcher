// handle file uploads in React using the HTML drag-and-drop API. 

/* readings:
https://www.smashingmagazine.com/2020/02/html-drag-drop-api-react/
https://blog.logrocket.com/react-drag-and-drop/
*/

import React from 'react';
import './DragAndDrop.css';

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
    };

    const handleDragLeave = e => {
        e.preventDefault();
        e.stopPropagation();
        console.log('Leave');
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
            dispatch({ type: 'SET_IN_DROP_ZONE', inDropZone: false });
        }
        /*
        We can access the dropped files with e.dataTransfer.files. 
        The value is an array-like object so we use the array spread syntax to convert it to a JavaScript array.
        We now need to check if there is at least one file before attempting to add it to our array of files. 
        We also make sure to not include files that are already on our fileList. 
        The dataTransfer object is cleared in preparation for the next drag-and-drop operation. 
        We also reset the values of inDropZone.
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
