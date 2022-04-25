import Home from './components/Home';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Register from './components/Register';
import MyChat from './components/MyChat';
import NotFound from './components/NotFound';
import { useState } from "react";

function App() {

  const [db, setDb] = useState([
    {username: "titinsky",nickname: "Amnon",password: "Free",photo:"data:image/jpeg;base64,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", contacts: ["shavit12", "phoebe"]},
    {username: "mj",nickname: "Michael Jordan",password: "MJ23",photo:"https://pbs.twimg.com/profile_images/3280964033/991799b389019646ef8815615660d74d_400x400.jpeg" ,contacts: ["d12", "joker", "avi_r", "skankhunter42", "s_cheeks"]},
    {username: "joker",nickname: "Arthur Fleck",password: "arkham!23",photo:"https://www.cinemascomics.com/wp-content/uploads/2020/09/Joaquin-Phoenix-joker-2-peliculas-mas.jpg", contacts: ["d12", "mj", "avi_r", "skankhunter42", "s_cheeks"]},
    {username: "d12",nickname: "David",password: "1234",photo:"" ,contacts: ["mj", "joker", "avi_r", "skankhunter42", "s_cheeks"]},
    {username: "skankhunter42",nickname: "Gerald",password: "E987#",photo:"" ,contacts: ["phoebe", "d12", "joker", "avi_r", "mj", "s_cheeks"]},
    {username: "s_cheeks",nickname: "Sandy",password: "KARATE",photo:"" ,contacts: ["d12", "joker", "avi_r", "skankhunter42", "mj"]},
    {username: "avi_r",nickname: "Avi",password: "12883",photo:"" ,contacts: ["d12", "joker", "mj", "skankhunter42", "s_cheeks"]},
    {username: "shavit12",nickname: "Kochava",password: "closed",photo:"" ,contacts: ["titinsky", "phoebe"]},
    {username: "phoebe",nickname: "Lisa",password: "Sme!1yCat",photo:"" ,contacts: ["titinsky", "shavit12", "skankhunter42"]},
    {username: "arod12",nickname: "Aaron",password: "Immunised",photo:"" ,contacts: []} 
]);

const [conversations, setConversations] = useState([
    {key:"titinsky|shavit12", messages:[{id:"1", message:"closed", sender:"shavit12", receiver:"titinsky", time: "2022-4-25 12:02:50"},
    {id:"2",message:"Nooooo", sender:"titinsky", receiver:"shavit12", time: "2022-4-25 17:20:53"},
    {id:"3",message:"https://youtu.be/om4UZCVqdsE", sender:"shavit12", receiver:"titinsky", time: "2022-4-25 17:22:50"}]},

    {key:"titinsky|phoebe", messages:[{id:"1",message:"Hello", sender:"titinsky", receiver:"phoebe", time: "2022-4-23 17:22:50"}]},

    {key:"mj|d12", messages:[{id:"1",message:"Hello", sender:"mj", receiver:"d12", time: "2022-4-23 17:22:50"},
    {id:"2",message:"Aloha", sender:"d12", receiver:"mj", time: "2022-4-25 11:22:50"},
    {id:"3",message:"Ola", sender:"d12", receiver:"mj", time: "2022-4-25 17:22:50"},
    {id:"4",message:"Prazer em conhecer voce", sender:"d12", receiver:"mj", time: "2022-4-25 17:22:58"},
    {id:"5",message:"???", sender:"mj", receiver:"d12", time: "2022-4-25 17:23:00"},
    {id:"6",message:"(:", sender:"d12", receiver:"mj", time: "2022-4-25 17:23:09"},
    {id:"7",message:"???", sender:"mj", receiver:"d12", time: "2022-4-25 17:24:50"},]},

    {key:"joker|mj", messages:[{id:"1",message:"Why So Serious?", sender:"joker", receiver:"mj", time: "2022-4-25 17:22:51"},
    {id:"2",message:"You either die a hero, or live long enough to see yourself become the villain.", sender:"mj", receiver:"joker", time: "2022-4-25 17:22:52"},
    {id:"3",message:"..,he's the hero Gotham deserves, but not the one it needs right now. So, we'll hunt him, because he can take it. Because he's not our hero.", sender:"mj", receiver:"joker", time: "2022-4-25 17:23:50"},
    {id:"4",message:"He's a silent guardian. A watchful protector. A Dark Knight.", sender:"mj", receiver:"joker", time: "2022-4-25 17:23:54"},
    {id:"5",message:"https://youtu.be/YTHtEpKBZh4", sender:"joker", receiver:"mj", time: "2022-4-25 17:23:56"},
    {id:"6",message:"https://youtu.be/LAr6oAKieHk", sender:"mj", receiver:"joker", time: "2022-4-25 17:24:55"}]}

]);

  const getDB = () => {
    return db;
  }

  const getUsernames = () => {
    var arr = [];
    db.map((e) => {arr.push(e.username)})
    return arr;
  }

  const getConversation = (username1, username2) => {
    var key1 = `${username1}|${username2}`;
    var key2 = `${username2}|${username1}`;
    const val = conversations.find((t) => t.key === key1 || t.key === key2)
    if (val) {
      return val.messages; 
    }
    return [{id:"1", message:"Waiting for messages...", sender:"ADMIN", receiver:"ADMIN", time:""}];
  } 

  const doesConvoExist = (username1, username2) => {
    var key1 = `${username1}|${username2}`;
    var key2 = `${username2}|${username1}`;
    const val = conversations.find((t) => t.key === key1 || t.key === key2)
    return !!(val);
  }

  const getNickname = (username) => {
    return db.find((u) => u.username === username).nickname
  }

  const getPhoto = (username) => {
    return db.find((u) => u.username === username).photo
  }

  const getLastMessage = (username, friends) => {
    let ans = [];
    friends && friends.map((friend) => {
      var convo = getConversation(username,friend).slice(-1);
      if (convo && convo.sender !== "ADMIN") {
        var temp = {username:friend, nickname:getNickname(friend), message:convo.at(0).message, photo:getPhoto(friend), time:convo.at(0).time};
        ans.push(temp);
      } else {
        ans.push({username:friend, nickname:getNickname(friend), photo:getPhoto(friend), message:"", time:""})
      }
    })
    return ans;
  }

  const addUser = (user) => {
    db.push({username:user.username, nickname:user.nickname, password:user.password, photo:user.photo, contacts:[]})
  }

  const isUsernameTaken = (username) => {
    if (username === "ADMIN") {return true}
    return !!(db.find(un => un.username === username));
  }

  const addFriend = (myUsername, friendUsername) => {
    !db.find((u) => u.username === myUsername).contacts.includes(friendUsername) && 
      db.find((u) => u.username === myUsername).contacts.push(friendUsername);
  }

  const getTimeStamp = () => {
    var today = new Date();
    var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    return date+' '+time;
  }

  const sendMessage = (fromUsername, toUsername, msg) => {
    if (!doesConvoExist(fromUsername, toUsername)) {
      addFriend(fromUsername, toUsername);
      addFriend(toUsername, fromUsername);
      conversations.push({key:`${fromUsername}|${toUsername}`, messages:[{id:"1", message:msg, sender:fromUsername, receiver:toUsername, time: getTimeStamp()}]})
    } else {
      var key1 = `${fromUsername}|${toUsername}`;
      var key2 = `${toUsername}|${fromUsername}`;
      const con = conversations.find((t) => t.key === key1 || t.key === key2)
      var mKey = con.messages.length + 1;
      con.messages.push({id:mKey.toString(), message:msg, sender:fromUsername, receiver:toUsername, time: getTimeStamp()})
    }
  }

  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home getDB={getDB} />}/>
        <Route path="/Register" element={<Register addUser={addUser} isUsernameTaken={isUsernameTaken}/>}/>
        <Route path="/users/:username" element={<MyChat getDB={getDB} getConversation={getConversation} getLastMessage={getLastMessage} getNickname={getNickname} getUsernames={getUsernames} getNick={getNickname} addFriend={addFriend} sendMessage={sendMessage} getPhoto={getPhoto}/>}/>
        <Route path="*" element={<NotFound />} />
      </Routes>
    </Router>
  );
}

export default App;
