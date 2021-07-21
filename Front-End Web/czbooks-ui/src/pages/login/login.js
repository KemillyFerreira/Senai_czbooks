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

    efetuaLogin = (event) => 
    {
        event.preventDefault();

        axios.post('http://localhost:5000/api/login',
        {
            //email tem que ser igual state.email, o mesmo vale para senha
            email : this.state.email,
            senha : this.state.senha
        })

        // se não for um, tenta o outro, não tem como ser os dois ao mesmo tempo
        .then(resposta =>
            {
                if(resposta.status == 200)

                //salva o token na base
                localStorage.setItem('login-usuario', resposta.data.token)
                console.log('Meu token é: '+ resposta.data.token)

                if(parseJwt().role == "1")
                {
                    console.log(this.props)
                    this.props.history.push('/atendimentos')
                }

                else
                {
                    this.props.history.push('/')
                }
            })
            .catch(erro => console.log(erro));
    };

    atualizaStateCampo = (campo) =>
    {
        this.setState({ [campo.target.name] : campo.target.value })
    }
   
}

export default Login;

