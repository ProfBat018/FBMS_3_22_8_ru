import React from 'react'
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

export default function LogOut() {
    const navigate = useNavigate();

    useEffect(() => {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");


    navigate("/login");
    window.location.reload();

    }, []);
  return (
    <div>LogOut</div>
  )
}
