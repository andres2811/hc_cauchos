PGDMP                         x         
   hc_cauchos    12.1    12.1                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    24699 
   hc_cauchos    DATABASE     �   CREATE DATABASE hc_cauchos WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Spanish_Colombia.1252' LC_CTYPE = 'Spanish_Colombia.1252';
    DROP DATABASE hc_cauchos;
                postgres    false                        2615    24700    usuario    SCHEMA        CREATE SCHEMA usuario;
    DROP SCHEMA usuario;
                postgres    false            �            1259    41039    rol_usuario    TABLE     �   CREATE TABLE usuario.rol_usuario (
    id integer NOT NULL,
    nombre character varying(50),
    sesion text,
    last_modify timestamp without time zone
);
     DROP TABLE usuario.rol_usuario;
       usuario         heap    postgres    false    6            �            1259    41037    rol_usuario_id_seq    SEQUENCE     �   CREATE SEQUENCE usuario.rol_usuario_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE usuario.rol_usuario_id_seq;
       usuario          postgres    false    6    206                       0    0    rol_usuario_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE usuario.rol_usuario_id_seq OWNED BY usuario.rol_usuario.id;
          usuario          postgres    false    205            �            1259    41028    usuario    TABLE     �  CREATE TABLE usuario.usuario (
    user_id integer NOT NULL,
    nombres character varying(40),
    apellidos character varying(50),
    correo character varying(75) NOT NULL,
    rol_id integer,
    contrasenia character varying(25) NOT NULL,
    fecha_nacimiento date,
    identificacion text NOT NULL,
    token text,
    estado_id integer,
    tiempo_token date,
    sesion text,
    last_modify timestamp with time zone
);
    DROP TABLE usuario.usuario;
       usuario         heap    postgres    false    6            �            1259    41026    usuario_user_id_seq    SEQUENCE     �   CREATE SEQUENCE usuario.usuario_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE usuario.usuario_user_id_seq;
       usuario          postgres    false    6    204                       0    0    usuario_user_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE usuario.usuario_user_id_seq OWNED BY usuario.usuario.user_id;
          usuario          postgres    false    203            �
           2604    41042    rol_usuario id    DEFAULT     r   ALTER TABLE ONLY usuario.rol_usuario ALTER COLUMN id SET DEFAULT nextval('usuario.rol_usuario_id_seq'::regclass);
 >   ALTER TABLE usuario.rol_usuario ALTER COLUMN id DROP DEFAULT;
       usuario          postgres    false    205    206    206            �
           2604    41031    usuario user_id    DEFAULT     t   ALTER TABLE ONLY usuario.usuario ALTER COLUMN user_id SET DEFAULT nextval('usuario.usuario_user_id_seq'::regclass);
 ?   ALTER TABLE usuario.usuario ALTER COLUMN user_id DROP DEFAULT;
       usuario          postgres    false    203    204    204                      0    41039    rol_usuario 
   TABLE DATA           G   COPY usuario.rol_usuario (id, nombre, sesion, last_modify) FROM stdin;
    usuario          postgres    false    206                    0    41028    usuario 
   TABLE DATA           �   COPY usuario.usuario (user_id, nombres, apellidos, correo, rol_id, contrasenia, fecha_nacimiento, identificacion, token, estado_id, tiempo_token, sesion, last_modify) FROM stdin;
    usuario          postgres    false    204                      0    0    rol_usuario_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('usuario.rol_usuario_id_seq', 1, false);
          usuario          postgres    false    205                       0    0    usuario_user_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('usuario.usuario_user_id_seq', 1, false);
          usuario          postgres    false    203            �
           2606    41047    rol_usuario rol_usuario_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY usuario.rol_usuario
    ADD CONSTRAINT rol_usuario_pkey PRIMARY KEY (id);
 G   ALTER TABLE ONLY usuario.rol_usuario DROP CONSTRAINT rol_usuario_pkey;
       usuario            postgres    false    206            �
           2606    41036    usuario usuario_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY usuario.usuario
    ADD CONSTRAINT usuario_pkey PRIMARY KEY (user_id);
 ?   ALTER TABLE ONLY usuario.usuario DROP CONSTRAINT usuario_pkey;
       usuario            postgres    false    204                  x������ � �            x������ � �     