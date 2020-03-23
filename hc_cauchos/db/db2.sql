PGDMP     /    5                x         
   hc_cauchos    12.1    12.1                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                        0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            !           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            "           1262    33116 
   hc_cauchos    DATABASE     �   CREATE DATABASE hc_cauchos WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Spanish_Spain.1252' LC_CTYPE = 'Spanish_Spain.1252';
    DROP DATABASE hc_cauchos;
                postgres    false                        2615    33140    security    SCHEMA        CREATE SCHEMA security;
    DROP SCHEMA security;
                postgres    false            #           0    0    SCHEMA security    COMMENT     G   COMMENT ON SCHEMA security IS 'Schema que se encarga de la auditoria';
                   postgres    false    6                        2615    33117    usuario    SCHEMA        CREATE SCHEMA usuario;
    DROP SCHEMA usuario;
                postgres    false            �            1259    33151 	   auditoria    TABLE     T  CREATE TABLE security.auditoria (
    id bigint NOT NULL,
    fecha timestamp without time zone NOT NULL,
    accion character varying(100),
    schema character varying(200) NOT NULL,
    tabla character varying(200),
    session text NOT NULL,
    user_bd character varying(100) NOT NULL,
    data jsonb NOT NULL,
    pk text NOT NULL
);
    DROP TABLE security.auditoria;
       security         heap    postgres    false    6            �            1259    33149    auditoria_id_seq    SEQUENCE     {   CREATE SEQUENCE security.auditoria_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE security.auditoria_id_seq;
       security          postgres    false    206    6            $           0    0    auditoria_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE security.auditoria_id_seq OWNED BY security.auditoria.id;
          security          postgres    false    205            �            1259    33118    rol_usuario    TABLE     `   CREATE TABLE usuario.rol_usuario (
    id integer NOT NULL,
    nombre character varying(50)
);
     DROP TABLE usuario.rol_usuario;
       usuario         heap    postgres    false    4            �            1259    33124    rol_usuario_id_seq    SEQUENCE     �   CREATE SEQUENCE usuario.rol_usuario_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE usuario.rol_usuario_id_seq;
       usuario          postgres    false    4    203            %           0    0    rol_usuario_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE usuario.rol_usuario_id_seq OWNED BY usuario.rol_usuario.id;
          usuario          postgres    false    204            �            1259    33170    usuario    TABLE     �  CREATE TABLE usuario.usuario (
    user_id integer NOT NULL,
    nombres character varying(40) NOT NULL,
    apellidos character varying(50) NOT NULL,
    correo character varying(75) NOT NULL,
    rol_id integer,
    clave character varying(25),
    fecha_nacimiento date NOT NULL,
    identificacion text NOT NULL,
    token text,
    tiempo_token timestamp without time zone,
    session text,
    last_modify timestamp without time zone,
    estado_id integer DEFAULT 1
);
    DROP TABLE usuario.usuario;
       usuario         heap    postgres    false    4            �            1259    33168    usuario_user_id_seq    SEQUENCE     �   CREATE SEQUENCE usuario.usuario_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE usuario.usuario_user_id_seq;
       usuario          postgres    false    208    4            &           0    0    usuario_user_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE usuario.usuario_user_id_seq OWNED BY usuario.usuario.user_id;
          usuario          postgres    false    207            �
           2604    33154    auditoria id    DEFAULT     p   ALTER TABLE ONLY security.auditoria ALTER COLUMN id SET DEFAULT nextval('security.auditoria_id_seq'::regclass);
 =   ALTER TABLE security.auditoria ALTER COLUMN id DROP DEFAULT;
       security          postgres    false    205    206    206            �
           2604    33134    rol_usuario id    DEFAULT     r   ALTER TABLE ONLY usuario.rol_usuario ALTER COLUMN id SET DEFAULT nextval('usuario.rol_usuario_id_seq'::regclass);
 >   ALTER TABLE usuario.rol_usuario ALTER COLUMN id DROP DEFAULT;
       usuario          postgres    false    204    203            �
           2604    33173    usuario user_id    DEFAULT     t   ALTER TABLE ONLY usuario.usuario ALTER COLUMN user_id SET DEFAULT nextval('usuario.usuario_user_id_seq'::regclass);
 ?   ALTER TABLE usuario.usuario ALTER COLUMN user_id DROP DEFAULT;
       usuario          postgres    false    208    207    208                      0    33151 	   auditoria 
   TABLE DATA           c   COPY security.auditoria (id, fecha, accion, schema, tabla, session, user_bd, data, pk) FROM stdin;
    security          postgres    false    206   �                 0    33118    rol_usuario 
   TABLE DATA           2   COPY usuario.rol_usuario (id, nombre) FROM stdin;
    usuario          postgres    false    203   �                 0    33170    usuario 
   TABLE DATA           �   COPY usuario.usuario (user_id, nombres, apellidos, correo, rol_id, clave, fecha_nacimiento, identificacion, token, tiempo_token, session, last_modify, estado_id) FROM stdin;
    usuario          postgres    false    208          '           0    0    auditoria_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('security.auditoria_id_seq', 1, false);
          security          postgres    false    205            (           0    0    rol_usuario_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('usuario.rol_usuario_id_seq', 1, false);
          usuario          postgres    false    204            )           0    0    usuario_user_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('usuario.usuario_user_id_seq', 3, true);
          usuario          postgres    false    207            �
           2606    33159    auditoria pk_security_auditoria 
   CONSTRAINT     _   ALTER TABLE ONLY security.auditoria
    ADD CONSTRAINT pk_security_auditoria PRIMARY KEY (id);
 K   ALTER TABLE ONLY security.auditoria DROP CONSTRAINT pk_security_auditoria;
       security            postgres    false    206            �
           2606    33137    rol_usuario rol_usuario_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY usuario.rol_usuario
    ADD CONSTRAINT rol_usuario_pkey PRIMARY KEY (id);
 G   ALTER TABLE ONLY usuario.rol_usuario DROP CONSTRAINT rol_usuario_pkey;
       usuario            postgres    false    203            �
           2606    33178    usuario usuario_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY usuario.usuario
    ADD CONSTRAINT usuario_pkey PRIMARY KEY (user_id);
 ?   ALTER TABLE ONLY usuario.usuario DROP CONSTRAINT usuario_pkey;
       usuario            postgres    false    208                  x������ � �            x�3�tL����,.)JL�/����� K�>         b   x�3��,K��t-.�,�L��rR!l#s��������\NC�JN##]c]##NC#cS3�?� 3 �H��������@�����ĘӐ+F��� f�7     