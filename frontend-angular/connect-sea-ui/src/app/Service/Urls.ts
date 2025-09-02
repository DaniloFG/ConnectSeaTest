// let urlLoginPrefix = 'http://localhost:8181';

let urlApiPrefixoLocal = ''; //'http://localhost:5049';
let urlApiPrefixoK8s = 'http://localhost:31673';
let urlApiPrefixo = '';
let isK8s = true;

if (isK8s) {
    urlApiPrefixo = urlApiPrefixoK8s;
}
else {
    urlApiPrefixo = urlApiPrefixoLocal;
}

export const Urls = {
    // urlLogin: urlLoginPrefix + '/api/Usuarios/autenticar',

    getEscala: urlApiPrefixo + '/api/connectseams1/getescala',
    getManifesto: urlApiPrefixo + '/api/connectseams1/getmanifesto',
    getManifestoEscala: urlApiPrefixo + '/api/connectseams1/getmanifestoescala',
    postManifestoEscala: urlApiPrefixo + '/api/connectseams1/postmanifestoescala',
}