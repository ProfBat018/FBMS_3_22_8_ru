import React, { useRef, useEffect } from 'react';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';

interface TextEditorProps {
    value: string;
    onChange: (value: string) => void;
}

const TextEditor: React.FC<TextEditorProps> = ({ value, onChange }) => {
    const quillRef = useRef<ReactQuill | null>(null);

    useEffect(() => {
        if (quillRef.current) {
            const editor = quillRef.current.getEditor();
        }
    }, []);

    return (
        <ReactQuill
            ref={quillRef}
            value={value}
            onChange={onChange}
        />
    );
};

export default TextEditor;
