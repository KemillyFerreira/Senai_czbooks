import React, { Component } from 'react';
import axios from 'axios';
import { parseJwt } from '../../services/auth'
import { div } from 'prelude-ls';

class Login extends Component 
{
    constructor(props)
    {
        super(props);
        this.state =
        {
            email : '',
            senha : ''
        };
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

                //verifica se o tipo de usuário logado é adm
                //caso seja, vai redirecionar para a página de atendimentos
                if(parseJwt().role == "1")
                {
                    console.log(this.props)
                    this.props.history.push('/atendimentos')
                }

                // se não for, redireciona para a página home
                else
                {
                    this.props.history.push('/')
                }
            })
            .catch(erro => console.log(erro));
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
                </form>

            </section>
        </div>
        )
    }
   
}

export default Login;

