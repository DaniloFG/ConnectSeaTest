let urlLoginPrefix = 'http://localhost:8181';
let urlApiPrefixo = 'http://localhost:5049';

export const Urls = {
    urlLogin: urlLoginPrefix + '/api/Usuarios/autenticar',

    getEscala: urlApiPrefixo + '/api/connectseams1/getescala',
    getManifesto: urlApiPrefixo + '/api/connectseams1/getmanifesto',
    getManifestoEscala: urlApiPrefixo + '/api/connectseams1/getmanifestoescala',
    postManifestoEscala: urlApiPrefixo + '/api/connectseams1/postmanifestoescala',
}