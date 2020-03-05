import * as actionTypes from "./actionTypes"

export const apiCallStarted = () => {
  return {
    type: actionTypes.API_CALL_STARTED
  }
}

export const ApiCallFailed = () => {
  return {
    type: actionTypes.API_CALL_FAILED
  }
}
