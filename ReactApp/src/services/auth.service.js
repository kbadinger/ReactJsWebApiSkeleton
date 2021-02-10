import axios from "axios";

const API_URL = "https://localhost:5001/";

const register = (username, email, password) => {
  return axios.post(API_URL + "Register/",  {
    username,
    email,
    password,
  });
};

const login = (username, password) => {

  let data = JSON.stringify({
    username: username,
    password: password
  });

  const ajaxHheaders = {
    'Content-Type': 'application/x-www-form-urlencoded',
};

  return axios
    .post(API_URL + "authenticate/", 
       { username: username , password: password}
    )
    .then((response) => {
      if (response.data.accessToken) {
        localStorage.setItem("user", JSON.stringify(response.data));
      }

      return response.data;
    });
};

const logout = () => {
  localStorage.removeItem("user");
};

export default {
  register,
  login,
  logout,
};