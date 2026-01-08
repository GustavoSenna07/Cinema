'use client';

import { ChangeEvent, useEffect, useState } from 'react';

type InputValue = string | number;

interface InputProps {
  label: string;
  placeHolder?: string;
  value?: string;
  type?: 'text' | 'email' | 'password' | 'date' | 'duration';
  required?: boolean;
  disabled?: boolean;
  error?: string;
  onChange?: (value: InputValue) => void;
}

export default function Input({
  label,
  placeHolder,
  value = '',
  type = 'text',
  required = false,
  disabled = false,
  error,
  onChange,
}: InputProps) {
  const inputId = label.toLowerCase().replace(/\s/g, '-');

  const [hours, setHours] = useState(0);
  const [minutes, setMinutes] = useState(0);

  useEffect(() => {
    if (type === 'duration') {
      onChange?.(hours * 60 + minutes);
    }
  }, [hours, minutes, type]);

  function renderField() {
    if (type === 'duration') {
      return (
        <div className="flex gap-4">
          <select
            aria-label="Horas"
            disabled={disabled}
            value={hours}
            onChange={(e) => setHours(Number(e.target.value))}
            className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black"
          >
            {Array.from({ length: 24 }).map((_, i) => (
              <option key={i} value={i}>
                {i} h
              </option>
            ))}
          </select>

          <select
            aria-label="Minutos"
            disabled={disabled}
            value={minutes}
            onChange={(e) => setMinutes(Number(e.target.value))}
            className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black"
          >
            {Array.from({ length: 60 }).map((_, i) => (
              <option key={i} value={i}>
                {i} min
              </option>
            ))}
          </select>
        </div>
      );
    }

    return (
      <input
        id={inputId}
        type={type}
        placeholder={placeHolder}
        value={value}
        required={required}
        disabled={disabled}
        onChange={(e: ChangeEvent<HTMLInputElement>) =>
          onChange?.(e.target.value)
        }
        className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black"
      />
    );
  }

  return (
    <div className="flex flex-col gap-1 w-full max-w-md">
      <label
        htmlFor={inputId}
        className="text-[rgba(182,80,250,1)] font-semibold"
      >
        {label}
      </label>

      {renderField()}

      {error && <span className="text-red-500 text-sm">{error}</span>}
    </div>
  );
}
