import React, { Component } from 'react'
import { connect } from 'dva'
import { Link } from 'dva/router'
import { Checkbox, Alert, Icon } from 'antd'
//import Login from '../../components/Login'
import styles from './Login.less'

//const { Tab, UserName, Password, Mobile, Captcha, Submit } = Login;

@connect(({ login, loading }) => ({
    login,
    submitting: loading.effects['login/login'],
}))
export default class LoginPage extends Component {
    state = {
        type: 'account',
        autoLogin: true,
    }

    onTabChange = (type) => {
        this.setState({ type })
    }

    handleSubmit = (err, values) => {
        const { type } = this.state
        if (!err) {
            this.props.dispatch({
                type: 'login/login',
                payload: {
                    ...values,
                    type,
                },
            })
        }
    }

    changeAutoLogin = (e) => {
        this.setState({
            autoLogin: e.target.checked,
        })
    }

    renderMessage = (content) => {
        return (
            <Alert style={{ marginBottom: 24 }} message={content} type="error" showIcon />
        )
    }

    render() {
        const { login, submitting } = this.props
        const { type } = this.state
        return (
            <div className={styles.main}>
                <div>
                    <Checkbox checked={this.state.autoLogin} onChange={this.changeAutoLogin}>自动登录</Checkbox>
                    <a style={{ float: 'right' }} href="">忘记密码</a>
                </div>
                <div className={styles.other}>
                    其他登录方式
                    <Icon className={styles.icon} type="alipay-circle" />
                    <Icon className={styles.icon} type="taobao-circle" />
                    <Icon className={styles.icon} type="weibo-circle" />
                    <Link className={styles.register} to="/user/register">注册账户</Link>
                </div>
            </div>
        )
    }
}
