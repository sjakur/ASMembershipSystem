import * as actionTypes from "../actions/actionTypes"
import initialState from "./initialState"

const apiStatusReducer = (state = initialState.apiCalls, action) => {
  if (action.type == actionTypes.API_CALL_STARTED) {
    return state + 1
  } else if (
    action.type == actionTypes.API_CALL_FAILED ||
    action.type.endsWith("SUCCESS")
  ) {
    return state - 1
  } else {
    return state
  }
}

export default apiStatusReducer
