import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import LockOutlined from '@material-ui/icons/LockOutlined';
import { useState } from 'react';

import { Link as RouterLink, useHistory}  from 'react-router-dom';

import Api from '../api';
import Loading from '../components/Loading';
import ErrorMessage from '../components/ErrorMessage';

function Copyright() {
    return (
        <Typography variant="body2" color="textSecondary" align="center">
            { new Date().getFullYear() }
        </Typography>  
    );
}

const useStyles = makeStyles((theme) => ({
    paper: {
        marginTop: theme.spacing(8),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    },
    avatar: {
        margin: theme.spacing(1),
        backgroundColor: theme.palette.secondary.main,
    },
    form: {
        width: '100%',
        marginTop: theme.spacing(3),
    },
    submit: {
        margin: theme.spacing(3, 0, 2),
    }
}));

export default function SignUp() {
    const classes = useStyles();
    const routeHistory = useHistory();

    // Loading component state
    const [openLoading, setOpenLoading] = useState(false);

    // Error message
    const [errorOpen, setErrorOpen] = useState(false);

    async function onSubmit(event) {
        event.preventDefault();
        setOpenLoading(true);

        const user = {
            firstName: document.getElementById('firstName').value,
            lastName: document.getElementById('lastName').value,
            email: document.getElementById('email').value,
            password: document.getElementById('password').value,
        }

        await Api.post('/users/signup', user)
            .then(() => setTimeout(() => {
                setOpenLoading(false);
                routeHistory.push('/');
            }, 1000))
            .catch(() => {
                setOpenLoading(false);
                setErrorOpen(true);
                setTimeout(() => {
                    setErrorOpen(false);
                }, 4000)
            });
    }

    return (
        <Container component="main" maxWidth="xs">
            <div className={classes.paper}>
                <Avatar className={classes.avatar}>
                    <LockOutlined />
                </Avatar>
                <Typography component="h1" variant="h5">
                    Sign up
                </Typography>
                <form className={classes.form} onSubmit={onSubmit}>
                    <Grid container spacing={2}>
                        <Grid item xs={12} sm={6}>
                            <TextField
                                autoComplete="fname"
                                name="firstName"
                                variant="outlined"
                                required
                                fullWidth
                                id="firstName"
                                label="First Name"
                                autoFocus
                            />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <TextField
                                autoComplete="lname"
                                name="lastName"
                                variant="outlined"
                                required
                                fullWidth
                                id="lastName"
                                label="Last Name"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                variant="outlined"
                                required
                                fullWidth
                                id="email"
                                label="Email Address"
                                name="email"
                                autoComplete="email"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                variant="outlined"
                                required
                                fullWidth
                                id="password"
                                label="Password"
                                name="password"
                                type="password"
                                autoComplete="current-password"
                            />
                        </Grid>
                    </Grid>

                    <Button
                        type="submit"
                        fullWidth
                        variant="contained"
                        color="primary"
                        className={classes.submit}
                    >
                        Sign Up
                    </Button>
                    <Loading open={openLoading}></Loading>
                    <ErrorMessage open={errorOpen}></ErrorMessage>

                    <Grid container justify="flex-end">
                        <Grid item>
                            <Link component={RouterLink} to="/signin" variant="body2">
                                Already have an account: Sign In
                            </Link>
                        </Grid>
                    </Grid>
                </form>
            </div>
            <Box mt={8}>
                <Copyright />
            </Box>
        </Container>
    );
}