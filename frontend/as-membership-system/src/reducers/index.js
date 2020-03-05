import { combineReducers } from "redux"
import membersReducer from "./membersReducer"
import memberDetailsReducer from "./memberDetailsReducer"
import apiStatusReducer from "./apiStatusReducer"
import sportsReducer from "./sportsReducer"

export default combineReducers({
  members: membersReducer,
  member: memberDetailsReducer,
  sports: sportsReducer,
  apiCalls: apiStatusReducer
})
