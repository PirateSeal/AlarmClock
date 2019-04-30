import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/preset";

export async function getPresetListAsync() {
    return await getAsync(endpoint);
}

export async function getPresetAsync(AlarmPresetId) {
    return await getAsync(`${endpoint}/${AlarmPresetId}`);
}

export async function createPresetAsync(preset) {
    return await postAsync(endpoint, preset);
}

export async function updatePresetAsync(preset) {
    return await putAsync(`${endpoint}/${preset.AlarmPresetId}`, preset);
}

export async function deletePresetAsync(AlarmPresetId) {
    return await deleteAsync(`${endpoint}/${AlarmPresetId}`);
}