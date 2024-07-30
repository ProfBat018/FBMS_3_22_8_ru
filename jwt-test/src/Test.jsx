import React from 'react';

function Test(props) {

    const testEndpoint = async (e) => {
        e.preventDefault();
      const data = await fetch("https://localhost:7281/api/Test", {
        method: "GET",
        headers: {
          "Content-Type": "application",
          "Authorization": `Bearer ${localStorage.getItem("accessToken")}`,
        },
    });
       

        console.log(data);
    }

    return (
        <div className="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
        <div className="sm:mx-auto sm:w-full sm:max-w-sm">
            <form onSubmit={testEndpoint}>

            <button type="submit" className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                Test endpoint
            </button>
            </form>
        </div>
        </div>
    );
}

export default Test;