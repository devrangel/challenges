import React from 'react';
import Snackbar from '@material-ui/core/Snackbar';

export default function ErrorMessage(props) {
    const {open} = props;

    return (
        <div>
            <Snackbar 
                open={open}
                anchorOrigin={{
                    vertical: 'bottom',
                    horizontal: 'center',
                }}
                message="Algum campo está inválido!"
            >
            </Snackbar>
        </div> 
    );
}