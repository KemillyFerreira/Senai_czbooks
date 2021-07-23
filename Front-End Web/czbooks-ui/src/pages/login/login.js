import React, { Component } from 'react';
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth'
import { div } from 'prelude-ls';

class Login extends Component 
{
    constructor(props)
    {
        super(props);
        this.state =
        {
            email : '',
            senha : '',
            erroMensagem   : '', 
            isLoading      : false
        }
    };

    // função que faz a chamada para a API para realizar o login
    efetuaLogin = (event) => 
    {
        //prevenir um comportamento padrão, por exemplo recarregar a página 
        event.preventDefault();

        axios.post('http://localhost:5000/api/login',
        {
            // email tem que ser igual state.email, o mesmo vale para senha
            email : this.state.email,
            senha : this.state.senha
        })

        // verifica o retorno da requisição; se não for um, tenta o outro, não tem como ser os dois ao mesmo tempo
        .then(resposta =>
            {
                // caso o status code seja 200
                if(resposta.status == 200)
               
                // salva o token no localStorage
                localStorage.setItem('login-usuario', resposta.data.token)
               
                // exibe o token no console do navegador
                console.log('Meu token é: '+ resposta.data.token)
                
                //define que a requisição terminou
                this.setState({ isLoading : false })

                //define que a variável base64 receberá o payload do token
                let base64 = localStorage.getItem('login-usuario').split('.')[1];

                //exibe o valor da base64 no console
                console.log(base64);

                //exibe o valor que foi convertido de base64 para string no console
                console.log(window.atob(base64));

                //exibe o valor que foi convertido de string para JSON
                console.log(JSON.parse(window.atob(base64)));

                //mostra apenas o tipo de usuario logado
                console.log(parseJwt().role);

                //verifica se o tipo de usuário logado é adm
                //caso seja, vai redirecionar para a página de atendimentos
                if(parseJwt().role == "1")
                {
                    console.log(this.props)
                    this.props.history.push('/atendimentos')
                    console.log('estou logado:' + usuarioAutenticado());
                }

                // se não for, redireciona para a página home
                else
                {
                    this.props.history.push('/')
                }
            })
        
            //se houver erro
            .catch(() => 
            {
                this.setState({ erroMensagem : 'E-mail ou senha inválidos! Tente novamente.', isLoading : false});
            })
    };

    // função genérica que atualiza o state de acordo com o input
    atualizaStateCampo = (campo) =>
    {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render()
    {
        return(
        <div>
            <h1>Login</h1>

            <section> 
                <form onSubmit={this.efetuaLogin}>
                    
                    <input
                        type="text"
                        name="email"
                        value={this.state.email}
                        onChange={this.atualizaStateCampo}
                        placeholder="username"
                        />          
                   
                    <input
                    type="password"
                    name="senha"
                    value={this.state.senha}
                    onChange={this.atualizaStateCampo}
                   placeholder={"password"}
                   />

                {/* traz a mensagem de erro caso o usuario informe credencias inválidas */}
                <p style={{ color : 'red', textAlign : 'center' }}>{this.state.erroMensagem}</p>

                {/* verifica se a requisição está em andamento, se sim, desabilita o click do botão */}
                
                {
                    // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                    this.state.isLoading === true &&
                    <div className="item">
                        <button className="btn btn__login" id="btn__login" type="submit" disabled>Loading...</button>"
                    </div>
                }
                
                {
                    // Caso seja false, renderiza o botão habilitado com o texto 'Login'
                    this.state.isLoading === false &&
                    <div className="item">
                        <button
                            className="btn btn__login" id="btn__login"
                            type="submit"
                            disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}>
                            Login
                        </button>
                    </div>
                }
               </form>
            </section>
        </div>
        )
    }
   
}

export default Login;

