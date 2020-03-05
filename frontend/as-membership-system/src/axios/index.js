import axios from "axios"

const instance = axios.create({
  baseURL: "http://localhost:64385/api"
})
export default instance
