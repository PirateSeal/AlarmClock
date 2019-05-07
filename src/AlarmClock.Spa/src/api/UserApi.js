import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/user";

export async function getUserIdByEmail(Email) {
    return await getAsync(endpoint,Email);
}

export async function getGlobalUserInfo() {
  return await getAsync(endpoint);
}
