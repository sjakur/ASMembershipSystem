import axios from "../axios"
import * as actionTypes from "./actionTypes"
import { apiCallStarted, ApiCallFailed } from "./apiStatusActions"

export const fetchSportsSuccess = data => {
  return {
    type: actionTypes.FETCH_SPORTS_SUCCESS,
    data
  }
}

export const fetchSports = () => {
  return dispatch => {
    dispatch(apiCallStarted())
    return axios
      .get("/sports")
      .then(response => {
        dispatch(fetchSportsSuccess(response.data))
      })
      .catch(error => {
        dispatch(ApiCallFailed())
        throw error
      })
  }
}
