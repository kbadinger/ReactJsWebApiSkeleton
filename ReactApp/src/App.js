
import "./App.css";
import { Provider, useDispatch, useSelector } from "react-redux";
import { makeStyles } from "@material-ui/core/styles";
import { ToastProvider } from "react-toast-notifications";
import React, { useState, useEffect } from "react";
import { Router, Switch, Route, Link } from "react-router-dom";
import Home from "./components/home";
  
import { clearMessage } from "./actions/message";

import { history } from "./helpers/history";
 

const App = () => {
 

  const dispatch = useDispatch();

  const drawerWidth = 240;
 

  useEffect(() => {
    history.listen((location) => {
      dispatch(clearMessage()); // clear message when changing location
    });
  }, [dispatch]);

  useEffect(() => { 
  } );

   

  return (
    <ToastProvider autoDismiss="true">     
    
       <Router history={history}>
       

                <div className="container mt-3">
                 

                    <Route path="/" component={Home} />

                   
                </div>
              
      
      </Router>
    </ToastProvider>
  );
};

export default App;
