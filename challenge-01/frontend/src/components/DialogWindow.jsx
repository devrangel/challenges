import Dialog from "@material-ui/core/Dialog";
import DialogTitle from "@material-ui/core/DialogTitle";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemAvatar from "@material-ui/core/ListItemAvatar";
import ListItemText from "@material-ui/core/ListItemText";
import Avatar from "@material-ui/core/Avatar";
import React from 'react';

import PropTypes from 'prop-types';


Dialog.propTypes = {
    onClose: PropTypes.func.isRequired,
    open: PropTypes.bool.isRequired,
};

export default function DialogWindow(props) {
    const { onClose, open , courses, moduleName} = props;

    const handleClose = () => {
        onClose();
    }

    return (
        <Dialog onClose={handleClose} aria-labelledby='simple-dialog-title' open={open}>
            <DialogTitle id='simple-dialog-title'>{moduleName}</DialogTitle>
            <List>
                {courses.map(course => (
                    <ListItem button key={course.id}>
                        <ListItemAvatar>
                            <Avatar src={course.imageSrc}></Avatar>
                        </ListItemAvatar>
                        <ListItemText primary={course.name} secondary={course.description}/>
                    </ListItem>
                ))}
            </List>
        </Dialog>
    );
}