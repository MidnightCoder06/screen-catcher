# Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.\
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can’t go back!**

If you aren’t satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you’re on your own.

You don’t have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn’t feel obligated to use this feature. However we understand that this tool wouldn’t be useful if you couldn’t customize it when you are ready for it.

### Analyzing the Bundle Size

This section has moved here: [https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size](https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size)

### Advanced Configuration

This section has moved here: [https://facebook.github.io/create-react-app/docs/advanced-configuration](https://facebook.github.io/create-react-app/docs/advanced-configuration)

### Deployment

This section has moved here: [https://facebook.github.io/create-react-app/docs/deployment](https://facebook.github.io/create-react-app/docs/deployment)

### `npm run build` fails to minify

This section has moved here: [https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify](https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify)


# Drag and Drop

## handle file uploads in React using the HTML drag-and-drop API instead of ReactDnD & React dropzone 3rd party packages

# The dragenter, dragleave, dragover, And drop Events

## The dragenter event fires when a dragged item enters a valid drop target.
## The dragleave event fires when a dragged item leaves a valid drop target.
## The dragover event fires when a dragged item is being dragged over a valid drop target. (It fires every few hundred milliseconds.)
## The drop event fires when an item drops on a valid drop target, i.e dragged over and released.


# Managing State 

## we have to consider how we intend to keep track of dropped files.
## We will be keeping track of the following states during the drag-and-drop operation:

## inDropZone
### This will be a boolean. We will use this to keep track of whether we’re inside the drop zone or not.

## FileList
### This will be a list. We’ll use it to keep track of files that have been dropped into the drop zone.


# File Uploads

## used the fetch API together with the FormData native Javascript API to post the file to the fileserver.
## https://developer.mozilla.org/en-US/docs/Web/API/FormData
## FormData is a special type of object which is not stringifyable can cannot just be printed out using console.log. 
## https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API
## native fetch over axios because I don't want to reduce the number of 3rd party libraries for this project