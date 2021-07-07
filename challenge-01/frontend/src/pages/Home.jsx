import { makeStyles } from '@material-ui/core/styles';
import React, { useState, useEffect } from 'react';
import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';

import { Link as RouterLink } from 'react-router-dom';

import Api from '../api';
import DialogWindow from '../components/DialogWindow';

const useStyles = makeStyles((theme) => ({
    futuro: {
        fontFamily: 'Tourney'
    },
    content: {
        padding: theme.spacing(8, 0, 6)
    },
    infos: {
        padding: theme.spacing(3, 0, 3, 0),
    },
    footer: {
        padding: theme.spacing(6),
    },
    cardGrid: {
        padding: theme.spacing(4),
    },
    cardRoot: {
        display: 'flex'
    },
    cardContent: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    },
    divButton: {
        display: 'flex',
        flexDirection: 'column',
    },
    button: {
        marginBottom: theme.spacing(1)
    },
    imageContainer: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        width: 140,
    },
    image: {
        width: 90,
    }
}));

export default function Home() {
    const classes = useStyles();

    // Para o Dialog
    const [open, setOpen] = useState(false);
    const [courses, setCourses] = useState([]);
    const [moduleName, setModuleName] = useState('');

    const handleClickOpen = async (id, moduleName) => {
        await Api.get(`/courses/modules/${id}`).then(res => {
            setCourses(res.data);
        })
        .catch(error => {
            console.error(error);
        })

        setModuleName(moduleName);
        setOpen(true);
    }

    const handleClose = () => {
        setOpen(false);
    };

    // Get Modules
    const [modules, setModules] = useState([]);
    useEffect(() => {
        Api.get('/modules').then(res => {
            setModules(res.data);
        })
        .catch(error => {
            console.error(error);
        })
    }, []);

    return (
        <React.Fragment>
            <main>
                
                <div className={classes.content}>
                    <Container maxWidth="sm">
                        <Typography component="h2" variant="h2" align="center" color="textPrimary" gutterBottom>
                            Programando o seu
                        </Typography>
                        <Typography className={classes.futuro} component="h2" variant="h2" align="center" color="textPrimary" gutterBottom>
                            futuro
                        </Typography>
                        <Typography className={classes.infos} variant="h5" align="center" color="textSecondary" paragraph>
                            Nossa missão é formar novos desenvolvedores de sistemas (Os famosos DEVs) de uma forma fácil e com muito profissionalismo.
                        </Typography>
                        <div>
                            <Grid container spacing={2} justify="center">
                                <Grid item>
                                    <Button component={RouterLink} to="/signin" variant="contained" color="primary">
                                        Sign in
                                    </Button>
                                </Grid>
                                <Grid item>
                                    <Button component={RouterLink} to="/signup" variant="outlined" color="primary">
                                        Sign up
                                    </Button>
                                </Grid>
                            </Grid>
                        </div>
                    </Container>
                </div>
                
                <Container className={classes.cardGrid}>
                    <Grid container spacing={4}>
                        {modules.map(mod => (
                            <Grid item key={mod.id} xs={12} sm={6} md={4}>
                                <Card className={classes.cardRoot}>
                                    <div className={classes.imageContainer}>
                                        <img className={classes.image} alt="" src={mod.imageSrc} />
                                    </div>
                                    <div className={classes.divContent}>
                                        <CardContent className={classes.cardContent}>
                                            <Typography component="h5" variant="h5">
                                                {mod.name}
                                            </Typography>
                                            <Typography color="textSecondary" variant="subtitle1">
                                                {mod.totalCourses} aulas | {mod.totalHours} horas
                                            </Typography>
                                        </CardContent>
                                        <div className={classes.divButton}>
                                            <Button
                                                className={classes.button}
                                                size="medium"
                                                color="primary"
                                                onClick={ () => handleClickOpen(mod.id, mod.name) }
                                            >
                                                Visualizar
                                            </Button>
                                        </div>
                                    </div>
                                </Card>
                            </Grid>
                        ))}
                    </Grid>
                </Container>
               
                <DialogWindow moduleName={moduleName} courses={courses} open={open} onClose={handleClose}></DialogWindow>
            </main>

            <footer mt={8} className={classes.footer}>
                <Typography variant="subtitle1" color="textSecondary" align="center">
                    Aprenda programação sem pagar nada
                </Typography>
                <Typography variant="subtitle1" color="textSecondary" align="center" component="p">
                    { new Date().getFullYear() }
                </Typography>
            </footer>
        </React.Fragment>
    );
}