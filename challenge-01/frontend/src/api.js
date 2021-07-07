import axios from 'axios';

const port = 44397;

const Api = axios.create({
    baseURL: `https://localhost:${port}`
});

export default Api;