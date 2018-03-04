import React from 'react'
import { routerRedux, Route, Switch } from 'dva/router'
import { LocaleProvider, Spin } from 'antd'
import dynamic from 'dva/dynamic'
import zhCN from 'antd/lib/locale-provider/zh_CN'

import styles from './index.less'
import { getRouterData } from './common/router'
import Authorized from './utils/Authorized'

const { ConnectedRouter } = routerRedux
const { AuthorizedRoute } = Authorized

dynamic.setDefaultLoadingComponent(() => {
    return <Spin size="large" className={styles.globalSpin} />
})

function RouterConfig({ history, app }) {
    const routerData = getRouterData(app)
    const UserLogin = routerData['/user/login'].component
    const Home = routerData['/'].component

    return (
        <LocaleProvider locale={zhCN}>
            <ConnectedRouter history={history}>
                <Switch>
                    <Route
                        path="/user/login"
                        component={UserLogin}
                    />
                    <AuthorizedRoute
                        path="/"
                        render={props => <Home {...props} />}
                        authority={['admin', 'user']}
                        redirectPath="/user/login"
                    />
                </Switch>
            </ConnectedRouter>
        </LocaleProvider>
    )
}

export default RouterConfig
