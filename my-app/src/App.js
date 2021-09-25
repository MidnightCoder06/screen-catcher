import React,{ useReducer } from 'react';
import DragAndDrop from './DragAndDrop';
import BrowseButton from './BrowseButton';
import './App.css'

function App() {


  const reducer = (state, action) => {
    switch (action.type) {
        case 'SET_DROP_DEPTH':
        return { ...state, dropDepth: action.dropDepth }
        case 'SET_IN_DROP_ZONE':
        return { ...state, inDropZone: action.inDropZone };
        case 'ADD_FILE_TO_LIST':
        return { ...state, fileList: state.fileList.concat(action.files) };
        default:
        return state;
    }
};

  const [data, dispatch] = useReducer(
    reducer, { dropDepth: 0, inDropZone: false, fileList: [] }
  )

  



  return (
    <div className={'app'}>
      <h1> Screen Catcher tool </h1>
      <DragAndDrop data={data}  dispatch={dispatch} />
      <ol className={"dropped-files"}>
        {data.fileList.map(file => {
          return (
            <li key={file.name}>{file.name}</li>
          )
        })}
      </ol>
      <BrowseButton />
    </div>
  );
}

export default App;
