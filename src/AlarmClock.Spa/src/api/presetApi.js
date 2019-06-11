import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/preset";

export async function getPresetListAsync() {
    return await getAsync(endpoint);
}

export async function getPresetAsync(Id) {
    return await getAsync(`${endpoint}/${Id}`);
}

export async function createPresetAsync(model) {
    return await postAsync(endpoint, model);
}

export async function updatePresetAsync(model) {
    return await putAsync(`${endpoint}/${model.AlarmPresetId}`, model);
}

export async function deletePresetAsync(Id) {
    return await deleteAsync(`${endpoint}/${Id}`);
}


