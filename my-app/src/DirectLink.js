import React, { useState } from 'react';
import './DirectLink.css';

/*
1. pull data from Redis to map to the link 
2. store in an Azure sql database that holds all generated links 
    - 4 columns:
        - uuid 
        - author     ... there is no login functionality in this app. In 'real life' this would taken from the browswer somehow
                            ... have a cloud function triggered that randomly picks a name from an external database you've created with a bunch of names in there 
        - timestamp 
        - link 
*/

/*
Needs to be aware of if an image has been uploaded or not. -> via context api?
If not then should flash red warning text that an image needs to be uploaded before you can click this
*/
const DirectLink = props => {

    const { contentUploaded } = props;
    console.log('from direct link', contentUploaded)

    const [btnClicked, setBtnClicked] = useState(false) 

    const handleClick = () => {
        setBtnClicked(true);
    }

    return (
        <>
            <button onClick={handleClick}> Click to generate a link </button>
            <p className="warning-text"> {btnClicked && !contentUploaded ? "please upload an image before generating a link" : ""}</p>
        </>
    );
}

export default DirectLink;