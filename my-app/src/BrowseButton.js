import React from 'react';

function BrowseButton() {

    function browseLocalFiles(e) {
        e.preventDefault();
        console.log('search a local file to upload');
    }

    return (
        <button onClick={browseLocalFiles}> 
            click to browse local files
        </button>
    );
}

export default BrowseButton;