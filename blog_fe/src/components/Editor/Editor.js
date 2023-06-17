import React, { useEffect, useRef, useState } from "react";
import Header from "@editorjs/header";
import List from "@editorjs/list";
import EditorJS from "@editorjs/editorjs";
import RawTool from "@editorjs/raw";
import Embed from "@editorjs/embed";
import CodeTool from "@editorjs/code";
import Table from "@editorjs/table";
import NestedList from "@editorjs/nested-list";
import InlineCode from "@editorjs/inline-code";
import SimpleImage from "@editorjs/simple-image";
import AttachesTool from "@editorjs/attaches";
import Delimiter from "@editorjs/delimiter";
import ImageTool from "@editorjs/image";
import LinkTool from "@editorjs/link";
import axios from "axios";
import { URL_BACKEND } from "../../constant";
const Editor = ({ onChangeValue }) => {
  const editorRef = useRef(null);
  console.log(onChangeValue);

  useEffect(() => {
    onChangeValue.dataCallback("Thang");
  }, [onChangeValue.HandleSubmitPost]);
  // const handleImageUpload = async (file) => {
  //   const imageUrl = await uploadImageToServer(file);

  //   if (editorRef.current) {
  //     editorRef.current.blocks.getTool("image").uploader.uploadByFile(imageUrl);
  //   }
  // };

  // const uploadImageToServer = async (file) => {
  //   const formData = new FormData();
  //   formData.append("file", file);
  //   const response = await fetch(`${URL_BACKEND}/api/UploadImage`, {
  //     method: "POST",
  //     body: formData,
  //   });

  //   const data = await response.json();
  //   return {
  //     success: 1,
  //     file: {
  //       url: data.imageUrl,
  //     },
  //   };
  // };

  const editor = new EditorJS({
    holder: "editorjs",
    onReady: () => {
      editorRef.current = editor;
    },
    onChange: async () => {
      let content = await editor.saver.save();
      console.log(content);
    },
    autofocus: true,
    tools: {
      delimiter: Delimiter,
      header: Header,
      table: Table,
      list: {
        class: List,
        inlineToolbar: true,
        config: {
          defaultStyle: "unordered",
        },
      },
      list: {
        class: NestedList,
        inlineToolbar: true,
        config: {
          defaultStyle: "unordered",
        },
      },
      inlineCode: {
        class: InlineCode,
        shortcut: "CMD+SHIFT+M",
      },
      linkTool: LinkTool,

      image: {
        class: ImageTool,
        config: {
          uploader: {
            async uploadByFile(file) {
              const formData = new FormData();
              formData.append("file", file);
              const response = await axios.post(`${URL_BACKEND}/api/UploadImage`, formData, {
                headers: {
                  "Content-Type": "multipart/form-data",
                },
              });
            },
          },
        },
      },
      raw: RawTool,
      code: CodeTool,
      embed: {
        class: Embed,
        config: {
          services: {
            youtube: true,
            coub: true,
          },
        },
      },
    },
  });
  editorRef.current = editor;

  return <div id="editorjs"></div>;
};

export default Editor;
