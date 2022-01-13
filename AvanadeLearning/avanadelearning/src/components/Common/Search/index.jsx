 import React from 'react';
// import { HiSearch } from 'react-icons/HiSearch';
import { SearchWrapper } from './style/SearchWrapper';

export function InputS({ value, method, icon, type, ...props }) {
    return(
        <SearchWrapper>
            <input
                type={type}
                value={value}
                onChange={method}
                {...props}
            />
                {icon}
        </SearchWrapper>
    )
}