// constante para ver se o usuário está loagdo
export const usuarioautenticado = () => localStorage.getItem('login-usuario') !== null;

// constante que retorna o payload do usuario covnvertido em JSON
export const parseJwt = () =>
{
    // define a variável que recebe o payload do usuario logado codificado
    let base64 =localStorage.getItem('login-usuario').split('.')[1];

    // decodifica a base64 para string
    // e converte a string para JSON
    return JSON.parse(window.atob(base64));
};