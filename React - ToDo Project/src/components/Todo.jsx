import React, { useRef } from "react";
import todoIcon from "../assets/todo_icon.png"
import Items from "./Items";


const Todo = () => {

    const [todoList, setTodoList] = React.useState([]);

    const inputRef = useRef();
    const add=() => {
        const text= inputRef.current.value.trim();
        if(text===""){
            alert("Please enter a task")}
            const newTodo={
                id: Date.now(),
                text: text,
                isCompleted: false,
            }
            setTodoList((prev)=> [...prev, newTodo]);
            inputRef.current.value="";
        }
    const deleteTodo =(id) => {
        setTodoList((prvToDo)=>{
          return  prvToDo.filter((todo) => todo.id !== id)
        })
    }

    return(
<div className="bg-white flex flex-col w-full max-w-[500px] p-5 min-h-[60vh] rounded-2xl shadow-lg mx-auto md:min-w-[75vh] md:min-h-[75vh]">

        {/*Title*/}  

    <div className="flex items-center mt-7 gab-2 justify-center">
        
        {/*<img className="w-8" src={todoIcon} alt="Iconita ToDo APP " />*/}
        <h1 className="text-3xl font-black ">To Do - List</h1>
    </div>


      {/*Task*/} 

    <div className="flex items-center my-7 bg-gray-200 rounded-full">
        <input  ref={inputRef} className="bg-transparent border-0 outline-none flex-1 h-14 pl-6 pr-2 placeholder:text-slate-600" type="text" placeholder="Add your task" />
        <button onClick={add} className="border-none rounded-full bg-orange-600 w-32 h-14 text-white font-bold text-lg cursor-pointer">ADD</button>
    </div> 
      {/*Task List*/}

      <div>
      {todoList.map((item,index)=>{
        return(<Items key={index} text={item.text} id={item.id} isCompleted={item.isCompleted} deleteTodo={deleteTodo}/>)
      })}

        </div> 

</div>


    )
}

export default Todo;