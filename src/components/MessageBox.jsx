import { useState } from "react";

const MessageBox = ({ username , pressedContact , pUsername , getConversation, sendMessage, sendHandler, getPhoto}) => {
    const [msg, setMsg] = useState('');
    const s = "sent";
    const r = "received";
    let mid;
    const [photo, setPhoto] = useState(null);
    const fr = new FileReader();


    const con = getConversation(username,pUsername);

    const send = (u1, u2, m) => {
        if (photo) {
            sendMessage(u1, u2, photo);
            sendHandler();
            setPhoto(null);
        }
        if (!m.trim().length) {return}
        sendMessage(u1, u2, m);
        sendHandler();
    }

    const handleChangePhoto = (e) => {
        const reader = new FileReader();
        reader.readAsDataURL(e.target.files[0]);
        reader.onloadend = () => {
            setPhoto(reader.result);
        };
    } 

    return ( 
        <div className="message-box">
            <div className="message-box-contact">
                <h2>{pressedContact}</h2>
                <img src={getPhoto(pUsername)} width="100" height="100"/>
            </div>
            <textarea type="text" placeholder="Type here..." onChange={(e) => setMsg(e.target.value)}/>
            <button onClick={() => send(username, pUsername, msg)}>Send</button>
            <div className="custom-file-upload">
                <input onChange={handleChangePhoto} type="file" name="image"/>
            </div>
            <button onClick={() => send(username, pUsername, msg)} onFocus={() => setMsg("")}>Record</button>
            <div className="message-box-conversation">
                {con.map(msgDetails => ( 
                    <div className="message" key={msgDetails.id}>
                        <div className="disappear">
                        {(msgDetails.sender === pUsername) ? mid = r : mid = s}
                        {(msgDetails.sender === "ADMIN") ? mid = "admin" : mid}
                        </div>
                        <div className={`message ${mid}`}>{msgDetails.message}</div>
                        <div className={`message ${mid}-time`}>{msgDetails.time}</div>
                    </div>
                ))}
            </div>
        </div>
     );
}
 
export default MessageBox;