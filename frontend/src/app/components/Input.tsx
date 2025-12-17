import { ChangeEvent } from "react";

interface InputProps {
  label: string;
  placeHolder?: string;
  value?: string;
  type?: "text"| "email"| "password";
  required: boolean;
  disabled: boolean;
  error?: string;
  onChange?: (e: ChangeEvent<HTMLInputElement>) => void;
}
export default function Input({
  placeHolder, 
  label, 
  value,
  type = "text",
  required = false,
  disabled = false,
  error,
  onChange
}:InputProps) {
  const inputId = label.toLowerCase().replace(/\s/g, "-");

  return (
    <div className="flex flex-col gap-1 w-2xl">
      <label
      htmlFor={inputId} 
      className="text-[rgba(182,80,250,1)] font-semibold">{label}</label>

      <input
      id={inputId} 
      type={type}
      placeholder={placeHolder}
      value={value}
      disabled={disabled}
      onChange={onChange}
      className=" bg-fuchsia-100 appearance-none px-3 py-2 rounded-lg text-black"/>
    </div>
  )
}