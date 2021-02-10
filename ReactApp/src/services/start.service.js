import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:5001/";

class StartService {
  getStartContent () {
  return axios.get(API_URL + "startcall");
};

  
}

export default new StartService();
