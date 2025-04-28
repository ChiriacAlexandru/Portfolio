import React from 'react'

import deleteIcon from "../assets/delete.png"

const Items = ({text, id, isCompleted, deleteTodo}) => {
  return (
    <div className='flex items-center my-3 gap-2'>
        <div className='flex flex-1 items-center cursor-pointer'>
            <p className='text-slate-700 ml-4 text-[17px]'>Task: {text}</p>
        </div>
        <img onClick={()=>{deleteTodo(id)}} src={deleteIcon} alt="" className='w-3.5 cursor-pointer' />
    </div>
  ) 
}

export default Items