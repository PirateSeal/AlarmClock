/*
 * File: clockApi.js                                                           *
 * Project: alarmclock                                                         *
 * File Created: Wednesday,3rd June 2019 11:27:24 am                           *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Tuesday, 11th June 2019 12:23:52 pm                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

import { getAsync } from "../helpers/apiHelper";

const endpoint = process.env.VUE_APP_BACKEND + "/api";

export async function getPresetList() {
    return await getAsync(`${endpoint}/preset`);
}

export async function getClockInfo() {
    let clock = await getAsync(`${endpoint}/clock`);
    clock = clock.acl.name;
    return clock;
}
