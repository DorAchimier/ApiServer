import { useState } from "react";
import Navbar from "./Navbar";
import { useNavigate } from 'react-router-dom';
const Home = () => {
    
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        var data = ({
        "username": username,
        "name": "nickname",
        "password": password,
        "server": "localhost:3000"
      });
    var options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }
    fetch("https://localhost:7033/api/validate", options).then(res => 
        {
            if (res.status != 200) {
                alert("Wrong username and/or password...")
            } else {
                navigate(`/users/${username}`)
            }
        })
    }


    return ( 
        <div className="App">
            <Navbar pageName="Sign Up" pageRef="/Register" extraText="New User?"/>
            <div className="content">
                <div className="create">
                    <h2>Welcome Back!</h2>
                    <form onSubmit={handleSubmit}>
                        <label>Username:</label>
                        <input 
                            type="text"
                            placeholder="Username"
                            required
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                        />
                        <label>Password:</label>
                        <input 
                            type="Password"
                            placeholder="Password"
                            required
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                        <button>Log In</button>
                    </form>
                </div>
            </div>
        </div>
     );
}
 
export default Home;