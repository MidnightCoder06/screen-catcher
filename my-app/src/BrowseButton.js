/* readings:
https://www.geeksforgeeks.org/how-to-create-a-upload-file-button-in-reactjs/
https://www.geeksforgeeks.org/file-uploading-in-react-js/
https://www.pluralsight.com/guides/uploading-files-with-reactjs
*/

import React, { useState, useEffect } from 'react';

function BrowseButton() {

    // selectedFile contains information on the currently picked file. -> initially, no file is selected
    const [selectedFile, setSelectedFile] = useState(null);
    // isFilePicked determines if a file has been picked or not.
	const [isSelected, setIsSelected] = useState(false);

    // useEffect(()=>{
    //     if (selectedFile) {
    //         //console.log('useEffect triggered')
    //         //console.log('hi from useEffect', selectedFile)
    //         // Create an object of formData
    //         const formData = new FormData();
    //         // Update the formData object
    //         formData.append('File', selectedFile);
    //         //console.log('data you are going to send to the backend from useEffect', formData )
    //     }
    // }, [selectedFile])

    const changeHandler = (event) => {
        console.log('details of the uploaded file', event.target.files[0]);
		setSelectedFile(event.target.files[0]); // event.target.files is an object that contains the details of files selected to be uploaded
		setIsSelected(true);
	};

	const handleSubmission = () => {
        console.log('submit button clicked');
        console.log('hi from submit btn', selectedFile)
        const formData = new FormData();
        // Update the formData object
        formData.append('File', selectedFile);
        //console.log('data you are going to send to the backend from submit btn click', formData )
        // https://stackoverflow.com/questions/56215041/formdata-returns-empty-data-on-form-submission-in-react
        // https://pretagteam.com/question/formdata-returns-empty-data-on-form-submission-in-react
        console.log(">>>>>>>>>>>>>>>>>>>")
        for (let [key, value] of formData.entries()) {
            console.log(key, value);
         }
        console.log(">>>>>>>>>>>>>>>>>>>")
        
        /*

        // Request made to the backend api -> Send formData object
            // store in some Azure blob storage + in Redis (do this in the backend)
		fetch(
			'https://freeimage.host/api/1/upload?key=<YOUR_API_KEY>',
			{
				method: 'POST',
				body: formData,
			}
		)
			.then((response) => response.json())
			.then((result) => {
				console.log('Success:', result);
			})
			.catch((error) => {
				console.error('Error:', error);
			});

        */

	};

    // the button is needed to work after a state refresh happens when the file is uploaded
    return(
        <div>
            <input type="file" name="file" onChange={changeHandler} />
            {isSelected ? (
                <div>
                    <p>Filename: {selectedFile.name}</p>
                    <p>Filetype: {selectedFile.type}</p>
                    <p>Size in bytes: {selectedFile.size}</p>
                    <p>
                        lastModifiedDate:{' '}
                        {selectedFile.lastModifiedDate.toLocaleDateString()}
                    </p>
                </div>
            ) : (
                <p>Select a file to show details</p>
            )}
            <div>
                <button onClick={handleSubmission}>Submit</button>
            </div>
        </div>
    );
}

export default BrowseButton;             
              