export const usuarioautenticado = () => localStorage.getItem('login-usuario') !== null;

export const parseJwt = () =>
{
    let base64 =localStorage.getItem('login-usuario').split('.')[1];

    return JSON.parse(window.atob(base64));
};