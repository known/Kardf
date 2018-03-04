export function getAuthority() {
    return localStorage.getItem('kardf-authority')
}

export function setAuthority(authority) {
    return localStorage.setItem('kardf-authority', authority)
}