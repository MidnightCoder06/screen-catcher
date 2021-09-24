import React from 'react';

import './DragAndDrop.css';

const DragAndDrop = props => {
    /*
    Each of these handler function receives the event object as its argument.
    For each of the event handlers, we call preventDefault() to stop the browser from executing its default behavior. 
    The default browser behavior is to open the dropped file. 
    We also call stopPropagation() to make sure that the event is not propagated from child to parent elements.
    */

  const handleDragEnter = e => {
    e.preventDefault();
    e.stopPropagation();
    console.log('Enter ');
  };

  const handleDragLeave = e => {
    e.preventDefault();
    e.stopPropagation();
    console.log('Leave');
  };

  const handleDragOver = e => {
    e.preventDefault();
    e.stopPropagation();
    console.log('Over');
  };

  const handleDrop = e => {
    e.preventDefault();
    e.stopPropagation();
    console.log('Drop');
  };

  return (
    <div className={'drag-drop-zone'}
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
