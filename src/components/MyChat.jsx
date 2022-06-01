import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import Navbar from "./Navbar";
import ContactsList from "./ContactsList";
import MessageBox from "./MessageBox";
import axios from "axios";

const MyChat = ( { getDB , getConversation, getLastMessage, getNickname, getUsernames, getNick, addFriend, sendMessage, getPhoto } ) => {
    const { username } = useParams();
    const url1 = "https://localhost:7033/api/";
    const url2 = "/nickname";
    const [ pressedContact, setPressedContact ] = useState(null);
    const [ pUsername, setPUsername ] = useState(null);
    const [ numOfSends, setNumOfSends ] = useState(0);
    const [ userDetails, setUserDetails ] = useState([]);
    const [ nickname, setNickname ] = useState([]);
    

    const addSend = () => {
        setNumOfSends(numOfSends + 1);
    }

    const clickHandle = (friend) => {
        setPressedContact(friend);
    }

    useEffect(() => { 
        axios.get(url1 + username + url2).then(res => {
            console.log(res)
            setNickname(res.data.name)
        }).catch(err => {console.log(err)})
        {pressedContact && <MessageBox username={username} pressedContact={pressedContact} pUsername={pUsername} getConversation={getConversation} sendMessage={sendMessage} sendHandler={addSend} getPhoto={getPhoto}/>}
        {<ContactsList username={username} clickHandle={clickHandle} getLastMessage={getLastMessage} getUsernames={getUsernames} getNickname={getNick} addFriend={addFriend}/>}

    }, [pressedContact, numOfSends]);
//
    return ( 
        <div className="App">
            <Navbar pageName="Sign Out" pageRef="/" extraText={nickname} />
            <div className="chat-screen">
                <ContactsList username={username} clickHandle={clickHandle} getLastMessage={getLastMessage} getUsernames={getUsernames} getNickname={getNick} addSend={addSend}/>
                {pressedContact && <MessageBox username={username} pressedContact={pressedContact} pUsername={pUsername}  getConversation={getConversation} sendMessage={sendMessage} sendHandler={addSend} getPhoto={getPhoto}/>}
            </div>
        </div>
     );
}
 
export default MyChat;