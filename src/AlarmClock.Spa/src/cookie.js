function setCookie (cname, cvalue, exhours) {
  let d = new Date()
  d.setTime(d.getTime() + (exhours * 24 * 60 * 60 * 1000))
  let expires = 'expires=' + d.toUTCString()
  document.cookie = cname + '=' + cvalue + ';' + expires + ';path=/'
};
function getCookie (cname) {
  let name = cname + '='
  let ca = document.cookie.split(';')
  for (let i = 0; i < ca.length; i++) {
    let c = ca[i]
    while (c.charAt(0) === ' ') {
      c = c.substring(1)
    }
    if (c.indexOf(name) === 0) {
      return c.substring(name.length, c.length)
    }
  }
  return ''
};
function deleteCookie (name) {
  setCookie(name, '', null, null, null, 1)
};
function checkCookie () {
  let user = getCookie('token')
  if (user !== '') {
    return user
  } else {
    return false
  }
};

export default {
  setCookie,
  getCookie,
  deleteCookie,
  checkCookie
}