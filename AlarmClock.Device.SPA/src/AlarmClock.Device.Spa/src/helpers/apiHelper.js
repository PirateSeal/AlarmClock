/*
 * File: apiHelper.js                                                          *
 * Project: alarmclock                                                         *
 * File Created: Tuesday,2nd June 2019 02:22:06 pm                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 6th June 2019 9:47:47 am                           *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

async function checkErrors(resp) {
    if (resp.ok) return resp;

    let errorMsg = `ERROR ${resp.status} (${resp.statusText})`;
    let serverText = await resp.text();
    if (serverText) errorMsg = `${errorMsg}: ${serverText}`;

    var error = new Error(errorMsg);
    error.response = resp;
    throw error;
}

async function toJSON(resp) {
    const result = await resp.text();
    if (result) return JSON.parse(result);
}

async function send(url, method, data, contentType, isRetrying) {
    let options = {
        method: method,
        headers: {},
        mode: "cors"
    };
    if (data) options.body = JSON.stringify(data);
    if (contentType) options.headers["Content-Type"] = contentType;

    let result = await fetch(url, options);
    if (result.status === 401 && !isRetrying) {
        await AuthService.refreshToken();
        send(url, method, data, contentType, true);
    }

    await checkErrors(result);
    return await toJSON(result);
}

export function postAsync(url, data) {
    return send(url, "POST", data, "application/json");
}

export function putAsync(url, data) {
    return send(url, "PUT", data, "application/json");
}

export function getAsync(url) {
    return send(url, "GET");
}

export function deleteAsync(url) {
    return send(url, "DELETE");
}
