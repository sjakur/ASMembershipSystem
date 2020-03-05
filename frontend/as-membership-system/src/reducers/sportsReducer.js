import * as actionTypes from "../actions/actionTypes"
import initialState from "./initialState"

const sportsReducer = (state = initialState.sports, action) => {
  switch (action.type) {
    case actionTypes.FETCH_SPORTS_SUCCESS:
      return action.data
    default:
      return state
  }
}

export default sportsReducer
