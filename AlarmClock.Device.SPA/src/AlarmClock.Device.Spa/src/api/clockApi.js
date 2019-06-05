import {
    getAsync,
    postAsync,
    putAsync,
    deleteAsync
} from "../helpers/apiHelper";
import { async } from "q";

const endpoint = process.env.VUE_APP_BACKEND + "/api/preset";

export async function getPresetList() {
    return await getAsync(`${endpoint}/${Id}`);
}

export async function getClockName() {
    return await getAsync(endpoint);
}
