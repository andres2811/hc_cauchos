PGDMP     #    ,                x         
   hc_cauchos    12.1    12.1 "    )           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            *           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            +           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ,           1262    41048 
   hc_cauchos    DATABASE     �   CREATE DATABASE hc_cauchos WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Spanish_Colombia.1252' LC_CTYPE = 'Spanish_Colombia.1252';
    DROP DATABASE hc_cauchos;
                postgres    false            	            2615    41049    security    SCHEMA        CREATE SCHEMA security;
    DROP SCHEMA security;
                postgres    false            -           0    0    SCHEMA security    COMMENT     G   COMMENT ON SCHEMA security IS 'Schema que se encarga de la auditoria';
                   postgres    false    9                        2615    41050    usuario    SCHEMA        CREATE SCHEMA usuario;
    DROP SCHEMA usuario;
                postgres    false            �            1255    41102    f_log_auditoria()    FUNCTION     �  CREATE FUNCTION security.f_log_auditoria() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
	 DECLARE
		_pk TEXT :='';		-- Representa la llave primaria de la tabla que esta siedno modificada.
		_sql TEXT;		-- Variable para la creacion del procedured.
		_column_guia RECORD; 	-- Variable para el FOR guarda los nombre de las columnas.
		_column_key RECORD; 	-- Variable para el FOR guarda los PK de las columnas.
		_session TEXT;	-- Almacena el usuario que genera el cambio.
		_user_db TEXT;		-- Almacena el usuario de bd que genera la transaccion.
		_control INT;		-- Variabel de control par alas llaves primarias.
		_count_key INT = 0;	-- Cantidad de columnas pertenecientes al PK.
		_sql_insert TEXT;	-- Variable para la construcción del insert del json de forma dinamica.
		_sql_delete TEXT;	-- Variable para la construcción del delete del json de forma dinamica.
		_sql_update TEXT;	-- Variable para la construcción del update del json de forma dinamica.
		_new_data RECORD; 	-- Fila que representa los campos nuevos del registro.
		_old_data RECORD;	-- Fila que representa los campos viejos del registro.

	BEGIN
			-- Se genera la evaluacion para determianr el tipo de accion sobre la tabla
		 IF (TG_OP = 'INSERT') THEN
			_new_data := NEW;
			_old_data := NEW;
		ELSEIF (TG_OP = 'UPDATE') THEN
			_new_data := NEW;
			_old_data := OLD;
		ELSE
			_new_data := OLD;
			_old_data := OLD;
		END IF;

		-- Se genera la evaluacion para determianr el tipo de accion sobre la tabla
		IF ((SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = TG_TABLE_SCHEMA AND table_name = TG_TABLE_NAME AND column_name = 'id' ) > 0) THEN
			_pk := _new_data.id;
		ELSE
			_pk := '-1';
		END IF;

		-- Se valida que exista el campo modified_by
		IF ((SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = TG_TABLE_SCHEMA AND table_name = TG_TABLE_NAME AND column_name = 'session') > 0) THEN
			_session := _new_data.session;
		ELSE
			_session := '';
		END IF;

		-- Se guarda el susuario de bd que genera la transaccion
		_user_db := (SELECT CURRENT_USER);

		-- Se evalua que exista el procedimeinto adecuado
		IF (SELECT COUNT(*) FROM security.function_db_view acfdv WHERE acfdv.b_function = 'field_audit' AND acfdv.b_type_parameters = TG_TABLE_SCHEMA || '.'|| TG_TABLE_NAME || ', '|| TG_TABLE_SCHEMA || '.'|| TG_TABLE_NAME || ', character varying, character varying, character varying, text, character varying, text, text') > 0
			THEN
				-- Se realiza la invocación del procedured generado dinamivamente
				PERFORM security.field_audit(_new_data, _old_data, TG_OP, _session, _user_db , _pk, ''::text);
		ELSE
			-- Se empieza la construcción del Procedured generico
			_sql := 'CREATE OR REPLACE FUNCTION security.field_audit( _data_new '|| TG_TABLE_SCHEMA || '.'|| TG_TABLE_NAME || ', _data_old '|| TG_TABLE_SCHEMA || '.'|| TG_TABLE_NAME || ', _accion character varying, _session text, _user_db character varying, _table_pk text, _init text)'
			|| ' RETURNS TEXT AS ''
'
			|| '
'
	|| '	DECLARE
'
	|| '		_column_data TEXT;
	 	_datos jsonb;
	 	
'
	|| '	BEGIN
			_datos = ''''{}'''';
';
			-- Se evalua si hay que actualizar la pk del registro de auditoria.
			IF _pk = '-1'
				THEN
					_sql := _sql
					|| '
		_column_data := ';

					-- Se genera el update con la clave pk de la tabla
					SELECT
						COUNT(isk.column_name)
					INTO
						_control
					FROM
						information_schema.table_constraints istc JOIN information_schema.key_column_usage isk ON isk.constraint_name = istc.constraint_name
					WHERE
						istc.table_schema = TG_TABLE_SCHEMA
					 AND	istc.table_name = TG_TABLE_NAME
					 AND	istc.constraint_type ilike '%primary%';

					-- Se agregan las columnas que componen la pk de la tabla.
					FOR _column_key IN SELECT
							isk.column_name
						FROM
							information_schema.table_constraints istc JOIN information_schema.key_column_usage isk ON isk.constraint_name = istc.constraint_name
						WHERE
							istc.table_schema = TG_TABLE_SCHEMA
						 AND	istc.table_name = TG_TABLE_NAME
						 AND	istc.constraint_type ilike '%primary%'
						ORDER BY 
							isk.ordinal_position  LOOP

						_sql := _sql || ' _data_new.' || _column_key.column_name;
						
						_count_key := _count_key + 1 ;
						
						IF _count_key < _control THEN
							_sql :=	_sql || ' || ' || ''''',''''' || ' ||';
						END IF;
					END LOOP;
				_sql := _sql || ';';
			END IF;

			_sql_insert:='
		IF _accion = ''''INSERT''''
			THEN
				';
			_sql_delete:='
		ELSEIF _accion = ''''DELETE''''
			THEN
				';
			_sql_update:='
		ELSE
			';

			-- Se genera el ciclo de agregado de columnas para el nuevo procedured
			FOR _column_guia IN SELECT column_name, data_type FROM information_schema.columns WHERE table_schema = TG_TABLE_SCHEMA AND table_name = TG_TABLE_NAME
				LOOP
						
					_sql_insert:= _sql_insert || '_datos := _datos || json_build_object('''''
					|| _column_guia.column_name
					|| '_nuevo'
					|| ''''', '
					|| '_data_new.'
					|| _column_guia.column_name;

					IF _column_guia.data_type IN ('bytea', 'USER-DEFINED') THEN 
						_sql_insert:= _sql_insert
						||'::text';
					END IF;

					_sql_insert:= _sql_insert || ')::jsonb;
				';

					_sql_delete := _sql_delete || '_datos := _datos || json_build_object('''''
					|| _column_guia.column_name
					|| '_anterior'
					|| ''''', '
					|| '_data_old.'
					|| _column_guia.column_name;

					IF _column_guia.data_type IN ('bytea', 'USER-DEFINED') THEN 
						_sql_delete:= _sql_delete
						||'::text';
					END IF;

					_sql_delete:= _sql_delete || ')::jsonb;
				';

					_sql_update := _sql_update || 'IF _data_old.' || _column_guia.column_name;

					IF _column_guia.data_type IN ('bytea','USER-DEFINED') THEN 
						_sql_update:= _sql_update
						||'::text';
					END IF;

					_sql_update:= _sql_update || ' <> _data_new.' || _column_guia.column_name;

					IF _column_guia.data_type IN ('bytea','USER-DEFINED') THEN 
						_sql_update:= _sql_update
						||'::text';
					END IF;

					_sql_update:= _sql_update || '
				THEN _datos := _datos || json_build_object('''''
					|| _column_guia.column_name
					|| '_anterior'
					|| ''''', '
					|| '_data_old.'
					|| _column_guia.column_name;

					IF _column_guia.data_type IN ('bytea','USER-DEFINED') THEN 
						_sql_update:= _sql_update
						||'::text';
					END IF;

					_sql_update:= _sql_update
					|| ', '''''
					|| _column_guia.column_name
					|| '_nuevo'
					|| ''''', _data_new.'
					|| _column_guia.column_name;

					IF _column_guia.data_type IN ('bytea', 'USER-DEFINED') THEN 
						_sql_update:= _sql_update
						||'::text';
					END IF;

					_sql_update:= _sql_update
					|| ')::jsonb;
			END IF;
			';
			END LOOP;

			-- Se le agrega la parte final del procedured generico
			
			_sql:= _sql || _sql_insert || _sql_delete || _sql_update
			|| ' 
		END IF;

		INSERT INTO security.auditoria
		(
			fecha,
			accion,
			schema,
			tabla,
			pk,
			session,
			user_bd,
			data
		)
		VALUES
		(
			CURRENT_TIMESTAMP,
			_accion,
			''''' || TG_TABLE_SCHEMA || ''''',
			''''' || TG_TABLE_NAME || ''''',
			_table_pk,
			_session,
			_user_db,
			_datos::jsonb
			);

		RETURN NULL; 
	END;'''
|| '
LANGUAGE plpgsql;';

			-- Se genera la ejecución de _sql, es decir se crea el nuevo procedured de forma generica.
			EXECUTE _sql;

		-- Se realiza la invocación del procedured generado dinamivamente
			PERFORM security.field_audit(_new_data, _old_data, TG_OP::character varying, _session, _user_db, _pk, ''::text);

		END IF;

		RETURN NULL;

END;
$$;
 *   DROP FUNCTION security.f_log_auditoria();
       security          postgres    false    9            �            1259    41059    rol_usuario    TABLE     `   CREATE TABLE usuario.rol_usuario (
    id integer NOT NULL,
    nombre character varying(50)
);
     DROP TABLE usuario.rol_usuario;
       usuario         heap    postgres    false    7            �            1255    41114 m   field_audit(usuario.rol_usuario, usuario.rol_usuario, character varying, text, character varying, text, text)    FUNCTION     \  CREATE FUNCTION security.field_audit(_data_new usuario.rol_usuario, _data_old usuario.rol_usuario, _accion character varying, _session text, _user_db character varying, _table_pk text, _init text) RETURNS text
    LANGUAGE plpgsql
    AS $$

	DECLARE
		_column_data TEXT;
	 	_datos jsonb;
	 	
	BEGIN
			_datos = '{}';

		IF _accion = 'INSERT'
			THEN
				_datos := _datos || json_build_object('id_nuevo', _data_new.id)::jsonb;
				_datos := _datos || json_build_object('nombre_nuevo', _data_new.nombre)::jsonb;
				
		ELSEIF _accion = 'DELETE'
			THEN
				_datos := _datos || json_build_object('id_anterior', _data_old.id)::jsonb;
				_datos := _datos || json_build_object('nombre_anterior', _data_old.nombre)::jsonb;
				
		ELSE
			IF _data_old.id <> _data_new.id
				THEN _datos := _datos || json_build_object('id_anterior', _data_old.id, 'id_nuevo', _data_new.id)::jsonb;
			END IF;
			IF _data_old.nombre <> _data_new.nombre
				THEN _datos := _datos || json_build_object('nombre_anterior', _data_old.nombre, 'nombre_nuevo', _data_new.nombre)::jsonb;
			END IF;
			 
		END IF;

		INSERT INTO security.auditoria
		(
			fecha,
			accion,
			schema,
			tabla,
			pk,
			session,
			user_bd,
			data
		)
		VALUES
		(
			CURRENT_TIMESTAMP,
			_accion,
			'usuario',
			'rol_usuario',
			_table_pk,
			_session,
			_user_db,
			_datos::jsonb
			);

		RETURN NULL; 
	END;$$;
 �   DROP FUNCTION security.field_audit(_data_new usuario.rol_usuario, _data_old usuario.rol_usuario, _accion character varying, _session text, _user_db character varying, _table_pk text, _init text);
       security          postgres    false    206    206    9            �            1259    41064    usuario    TABLE     �  CREATE TABLE usuario.usuario (
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
       usuario         heap    postgres    false    7            �            1255    41112 e   field_audit(usuario.usuario, usuario.usuario, character varying, text, character varying, text, text)    FUNCTION       CREATE FUNCTION security.field_audit(_data_new usuario.usuario, _data_old usuario.usuario, _accion character varying, _session text, _user_db character varying, _table_pk text, _init text) RETURNS text
    LANGUAGE plpgsql
    AS $$

	DECLARE
		_column_data TEXT;
	 	_datos jsonb;
	 	
	BEGIN
			_datos = '{}';

		_column_data :=  _data_new.user_id;
		IF _accion = 'INSERT'
			THEN
				_datos := _datos || json_build_object('user_id_nuevo', _data_new.user_id)::jsonb;
				_datos := _datos || json_build_object('nombres_nuevo', _data_new.nombres)::jsonb;
				_datos := _datos || json_build_object('apellidos_nuevo', _data_new.apellidos)::jsonb;
				_datos := _datos || json_build_object('correo_nuevo', _data_new.correo)::jsonb;
				_datos := _datos || json_build_object('rol_id_nuevo', _data_new.rol_id)::jsonb;
				_datos := _datos || json_build_object('clave_nuevo', _data_new.clave)::jsonb;
				_datos := _datos || json_build_object('fecha_nacimiento_nuevo', _data_new.fecha_nacimiento)::jsonb;
				_datos := _datos || json_build_object('identificacion_nuevo', _data_new.identificacion)::jsonb;
				_datos := _datos || json_build_object('token_nuevo', _data_new.token)::jsonb;
				_datos := _datos || json_build_object('tiempo_token_nuevo', _data_new.tiempo_token)::jsonb;
				_datos := _datos || json_build_object('session_nuevo', _data_new.session)::jsonb;
				_datos := _datos || json_build_object('last_modify_nuevo', _data_new.last_modify)::jsonb;
				_datos := _datos || json_build_object('estado_id_nuevo', _data_new.estado_id)::jsonb;
				
		ELSEIF _accion = 'DELETE'
			THEN
				_datos := _datos || json_build_object('user_id_anterior', _data_old.user_id)::jsonb;
				_datos := _datos || json_build_object('nombres_anterior', _data_old.nombres)::jsonb;
				_datos := _datos || json_build_object('apellidos_anterior', _data_old.apellidos)::jsonb;
				_datos := _datos || json_build_object('correo_anterior', _data_old.correo)::jsonb;
				_datos := _datos || json_build_object('rol_id_anterior', _data_old.rol_id)::jsonb;
				_datos := _datos || json_build_object('clave_anterior', _data_old.clave)::jsonb;
				_datos := _datos || json_build_object('fecha_nacimiento_anterior', _data_old.fecha_nacimiento)::jsonb;
				_datos := _datos || json_build_object('identificacion_anterior', _data_old.identificacion)::jsonb;
				_datos := _datos || json_build_object('token_anterior', _data_old.token)::jsonb;
				_datos := _datos || json_build_object('tiempo_token_anterior', _data_old.tiempo_token)::jsonb;
				_datos := _datos || json_build_object('session_anterior', _data_old.session)::jsonb;
				_datos := _datos || json_build_object('last_modify_anterior', _data_old.last_modify)::jsonb;
				_datos := _datos || json_build_object('estado_id_anterior', _data_old.estado_id)::jsonb;
				
		ELSE
			IF _data_old.user_id <> _data_new.user_id
				THEN _datos := _datos || json_build_object('user_id_anterior', _data_old.user_id, 'user_id_nuevo', _data_new.user_id)::jsonb;
			END IF;
			IF _data_old.nombres <> _data_new.nombres
				THEN _datos := _datos || json_build_object('nombres_anterior', _data_old.nombres, 'nombres_nuevo', _data_new.nombres)::jsonb;
			END IF;
			IF _data_old.apellidos <> _data_new.apellidos
				THEN _datos := _datos || json_build_object('apellidos_anterior', _data_old.apellidos, 'apellidos_nuevo', _data_new.apellidos)::jsonb;
			END IF;
			IF _data_old.correo <> _data_new.correo
				THEN _datos := _datos || json_build_object('correo_anterior', _data_old.correo, 'correo_nuevo', _data_new.correo)::jsonb;
			END IF;
			IF _data_old.rol_id <> _data_new.rol_id
				THEN _datos := _datos || json_build_object('rol_id_anterior', _data_old.rol_id, 'rol_id_nuevo', _data_new.rol_id)::jsonb;
			END IF;
			IF _data_old.clave <> _data_new.clave
				THEN _datos := _datos || json_build_object('clave_anterior', _data_old.clave, 'clave_nuevo', _data_new.clave)::jsonb;
			END IF;
			IF _data_old.fecha_nacimiento <> _data_new.fecha_nacimiento
				THEN _datos := _datos || json_build_object('fecha_nacimiento_anterior', _data_old.fecha_nacimiento, 'fecha_nacimiento_nuevo', _data_new.fecha_nacimiento)::jsonb;
			END IF;
			IF _data_old.identificacion <> _data_new.identificacion
				THEN _datos := _datos || json_build_object('identificacion_anterior', _data_old.identificacion, 'identificacion_nuevo', _data_new.identificacion)::jsonb;
			END IF;
			IF _data_old.token <> _data_new.token
				THEN _datos := _datos || json_build_object('token_anterior', _data_old.token, 'token_nuevo', _data_new.token)::jsonb;
			END IF;
			IF _data_old.tiempo_token <> _data_new.tiempo_token
				THEN _datos := _datos || json_build_object('tiempo_token_anterior', _data_old.tiempo_token, 'tiempo_token_nuevo', _data_new.tiempo_token)::jsonb;
			END IF;
			IF _data_old.session <> _data_new.session
				THEN _datos := _datos || json_build_object('session_anterior', _data_old.session, 'session_nuevo', _data_new.session)::jsonb;
			END IF;
			IF _data_old.last_modify <> _data_new.last_modify
				THEN _datos := _datos || json_build_object('last_modify_anterior', _data_old.last_modify, 'last_modify_nuevo', _data_new.last_modify)::jsonb;
			END IF;
			IF _data_old.estado_id <> _data_new.estado_id
				THEN _datos := _datos || json_build_object('estado_id_anterior', _data_old.estado_id, 'estado_id_nuevo', _data_new.estado_id)::jsonb;
			END IF;
			 
		END IF;

		INSERT INTO security.auditoria
		(
			fecha,
			accion,
			schema,
			tabla,
			pk,
			session,
			user_bd,
			data
		)
		VALUES
		(
			CURRENT_TIMESTAMP,
			_accion,
			'usuario',
			'usuario',
			_table_pk,
			_session,
			_user_db,
			_datos::jsonb
			);

		RETURN NULL; 
	END;$$;
 �   DROP FUNCTION security.field_audit(_data_new usuario.usuario, _data_old usuario.usuario, _accion character varying, _session text, _user_db character varying, _table_pk text, _init text);
       security          postgres    false    208    208    9            �            1259    41051 	   auditoria    TABLE     K  CREATE TABLE security.auditoria (
    id bigint NOT NULL,
    fecha timestamp without time zone NOT NULL,
    accion character varying(100),
    schema character varying(200) NOT NULL,
    tabla character varying(200),
    session text,
    user_bd character varying(100) NOT NULL,
    data jsonb NOT NULL,
    pk text NOT NULL
);
    DROP TABLE security.auditoria;
       security         heap    postgres    false    9            �            1259    41057    auditoria_id_seq    SEQUENCE     {   CREATE SEQUENCE security.auditoria_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE security.auditoria_id_seq;
       security          postgres    false    9    204            .           0    0    auditoria_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE security.auditoria_id_seq OWNED BY security.auditoria.id;
          security          postgres    false    205            �            1259    41107    function_db_view    VIEW     �  CREATE VIEW security.function_db_view AS
 SELECT pp.proname AS b_function,
    oidvectortypes(pp.proargtypes) AS b_type_parameters
   FROM (pg_proc pp
     JOIN pg_namespace pn ON ((pn.oid = pp.pronamespace)))
  WHERE ((pn.nspname)::text <> ALL (ARRAY[('pg_catalog'::character varying)::text, ('information_schema'::character varying)::text, ('admin_control'::character varying)::text, ('vial'::character varying)::text]));
 %   DROP VIEW security.function_db_view;
       security          postgres    false    9            �            1259    41062    rol_usuario_id_seq    SEQUENCE     �   CREATE SEQUENCE usuario.rol_usuario_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE usuario.rol_usuario_id_seq;
       usuario          postgres    false    7    206            /           0    0    rol_usuario_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE usuario.rol_usuario_id_seq OWNED BY usuario.rol_usuario.id;
          usuario          postgres    false    207            �            1259    41071    usuario_user_id_seq    SEQUENCE     �   CREATE SEQUENCE usuario.usuario_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE usuario.usuario_user_id_seq;
       usuario          postgres    false    208    7            0           0    0    usuario_user_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE usuario.usuario_user_id_seq OWNED BY usuario.usuario.user_id;
          usuario          postgres    false    209            �
           2604    41073    auditoria id    DEFAULT     p   ALTER TABLE ONLY security.auditoria ALTER COLUMN id SET DEFAULT nextval('security.auditoria_id_seq'::regclass);
 =   ALTER TABLE security.auditoria ALTER COLUMN id DROP DEFAULT;
       security          postgres    false    205    204            �
           2604    41074    rol_usuario id    DEFAULT     r   ALTER TABLE ONLY usuario.rol_usuario ALTER COLUMN id SET DEFAULT nextval('usuario.rol_usuario_id_seq'::regclass);
 >   ALTER TABLE usuario.rol_usuario ALTER COLUMN id DROP DEFAULT;
       usuario          postgres    false    207    206            �
           2604    41075    usuario user_id    DEFAULT     t   ALTER TABLE ONLY usuario.usuario ALTER COLUMN user_id SET DEFAULT nextval('usuario.usuario_user_id_seq'::regclass);
 ?   ALTER TABLE usuario.usuario ALTER COLUMN user_id DROP DEFAULT;
       usuario          postgres    false    209    208            !          0    41051 	   auditoria 
   TABLE DATA           c   COPY security.auditoria (id, fecha, accion, schema, tabla, session, user_bd, data, pk) FROM stdin;
    security          postgres    false    204   Ga       #          0    41059    rol_usuario 
   TABLE DATA           2   COPY usuario.rol_usuario (id, nombre) FROM stdin;
    usuario          postgres    false    206   �f       %          0    41064    usuario 
   TABLE DATA           �   COPY usuario.usuario (user_id, nombres, apellidos, correo, rol_id, clave, fecha_nacimiento, identificacion, token, tiempo_token, session, last_modify, estado_id) FROM stdin;
    usuario          postgres    false    208   g       1           0    0    auditoria_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('security.auditoria_id_seq', 38, true);
          security          postgres    false    205            2           0    0    rol_usuario_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('usuario.rol_usuario_id_seq', 1, false);
          usuario          postgres    false    207            3           0    0    usuario_user_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('usuario.usuario_user_id_seq', 8, true);
          usuario          postgres    false    209            �
           2606    41077    auditoria pk_security_auditoria 
   CONSTRAINT     _   ALTER TABLE ONLY security.auditoria
    ADD CONSTRAINT pk_security_auditoria PRIMARY KEY (id);
 K   ALTER TABLE ONLY security.auditoria DROP CONSTRAINT pk_security_auditoria;
       security            postgres    false    204            �
           2606    41079    rol_usuario rol_usuario_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY usuario.rol_usuario
    ADD CONSTRAINT rol_usuario_pkey PRIMARY KEY (id);
 G   ALTER TABLE ONLY usuario.rol_usuario DROP CONSTRAINT rol_usuario_pkey;
       usuario            postgres    false    206            �
           2606    41081    usuario usuario_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY usuario.usuario
    ADD CONSTRAINT usuario_pkey PRIMARY KEY (user_id);
 ?   ALTER TABLE ONLY usuario.usuario DROP CONSTRAINT usuario_pkey;
       usuario            postgres    false    208            �
           2620    41113 !   rol_usuario tg_usuario_rolusuario    TRIGGER     �   CREATE TRIGGER tg_usuario_rolusuario AFTER INSERT OR DELETE OR UPDATE ON usuario.rol_usuario FOR EACH ROW EXECUTE FUNCTION security.f_log_auditoria();
 ;   DROP TRIGGER tg_usuario_rolusuario ON usuario.rol_usuario;
       usuario          postgres    false    211    206            �
           2620    41104    usuario tg_usuario_usuario    TRIGGER     �   CREATE TRIGGER tg_usuario_usuario AFTER INSERT OR DELETE OR UPDATE ON usuario.usuario FOR EACH ROW EXECUTE FUNCTION security.f_log_auditoria();
 4   DROP TRIGGER tg_usuario_usuario ON usuario.usuario;
       usuario          postgres    false    211    208            !   q  x�ř݋�6����"�+�}���ۇ�RJ{}+,n�u��K�,����c+ql���ɚ��[i�7�)b������D��r���~��×�ű<���h����>)W_��K�o��x�Z������u^������c�V����9���d�ݪ�*�	��W�zY�b	!���aN:X|z��q*�&�ߒ�:X������E~�2�|S��I��QKvV��_��.N3�)v��}�=���Z1`��eR�i��x�eA��X&�@�����$��mQ^#6[��o��,.O�b�>���~q����H*�Z:���d�Z<y,�&�!}N7�&4LpÝ���.N�)�e���t�,��B<����a&����2����/MTq8��>9����撖dU���H!,�>����uأn[��M���>R�Ku��T\�t���-�N.u�x���xe��jTu���i�����U�ya���ͧ~Ѫ�ુB:�R�*�2��P��]?��	��%���+����MWo�bL_��L����߳���?+f}[���mȎ
�@pC���|�X���t2�Oҕ�ۅ�&�qa��s`�xŌBPr$vhl�-x����*UPY�gJ��PNM�o'��!<D���13����O:��]n|`���i�b����nN��tM������cc�-E�I#���ۋ: ����[��UP���V͕+^��pt���Uo#�����f���kFQ>�x���^�RD� �v�����Ǳm=4�Û��5�����t�ZL�doxU��H�4s��UH-G���b��BvA���ѳ��IZ9��t,�W��j�q^!�(�U�7:`��ڵד��\�HYȵ��1Ƌ�.�����9<7܀8���m���4�k=7�HC5������:�m�N�����2D�5�*B�����
A	;>�{=�
�%D � y}6��u�s��1����T���@�;�סף50��w�SG�U-��=�0�� I#�������+��Τ���,-�|�%�c�Ao&^�;&�g�2���`���{+��o%��۞Iz�s�3	����c��Wpa8eu�X n�P8���-�W�$+6/�{;�}'�����ި^����􇶳盆�����<���!��*h1�?�q�v����NXe_X덽A�0�E�D����r�S?�R��4գ<#��u`���0֋J7��\��s\� 5���=f<�Κ�OT��x/h8����8�Z8*twQː��Ť���te�� ��bW���2Õ��S�i~�(GϤAqxnp#���Z�ᧆ۹��G��Z��q�}
��poy�u���oSAQ{�p%�tY��n`�����<��x� (��w�\.���      #   <   x�3�tL����,.)JL�/�2�L�-�I���9S�s3�3s2�2�L8K�K��=... -,T      %     x�e�An�0��p
. �36�Yu�E7=A�ʢ(q&
��5�iH^���=>����x��5`ݹ�2��֎�B�]��7�˛���YA"$�J8}.k)I%�?Q*�F�Q�
�V>�(�p6�Ÿ�^M���P&D�Ŋ�zҗ�WX�~�R!��-�tvtm?��c����T�����4ķQM�s����*h���[}��e�W�'���,���C����r`�Z���$?�qzs�a���^���LR+���t�$�9kA_���$I�  ���     