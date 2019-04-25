import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/clockController";

export async function getClockListAsync() {
    return await getAsync(endpoint);
}

export async function getClockAsync(Id) {
    return await getAsync(`${endpoint}/${Id}`);
}

export async function createClockAsync(model) {
    return await postAsync(endpoint, model);
}

export async function updateClockAsync(model) {
    return await putAsync(`${endpoint}/${model.studentId}`, model);
}

export async function deleteClockAsync(Id) {
    return await deleteAsync(`${endpoint}/${Id}`);
}