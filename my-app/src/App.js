import React, { useReducer, useState } from 'react';
import DragAndDrop from './DragAndDrop';
import BrowseButton from './BrowseButton';
import DirectLink from './DirectLink';
import './App.css'

function App() {

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

  /*
    Links to some reading on the context api 

    https://dev.to/olenadrugalya/managing-state-with-react-context-4h2h

  */

  const reducer = (state, action) => {
    switch (action.type) {
        case 'SET_IN_DROP_ZONE':
          return { ...state, inDropZone: action.inDropZone };
        case 'ADD_FILE_TO_LIST':
          return { ...state, fileList: state.fileList.concat(action.files) };
        default:
          return state;
    }
 };

  const [data, dispatch] = useReducer(
    reducer, { inDropZone: false, fileList: [] }
  )

  const [contentUploaded, setContentUploaded] = useState(false);

  return (
    <div className={'app'}>
      <h1> Screen Catcher Tool </h1>
      <DragAndDrop data={data}  dispatch={dispatch} setContentUploaded={setContentUploaded} />
      <ol className={"dropped-files"}>
        {data.fileList.map(file => {
          return (
            <li key={file.name}>{file.name}</li>
          )
        })}
      </ol>
      <BrowseButton setContentUploaded={setContentUploaded} />
      <DirectLink contentUploaded={contentUploaded} />
    </div>
  );
}

export default App;
