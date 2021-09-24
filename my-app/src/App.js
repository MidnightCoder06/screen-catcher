import React from 'react';
import DragAndDrop from './DragAndDrop';
import BrowseButton from './BrowseButton';

import './App.css'

function App() {
  return (
    <div className={'app'}>
      <h1> Screen Catcher tool </h1>
      <DragAndDrop />
      <BrowseButton />
    </div>
  );
}

export default App;
