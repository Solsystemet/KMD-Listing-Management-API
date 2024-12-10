import styles from "./Checkbox.module.css";

type CheckboxProps = {
  children: string;
  id: string;
  name: string;
  value: boolean;
  onBlur: (e: React.FocusEvent<HTMLInputElement>) => void;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  required?: boolean;
};

export function Checkbox({
  children,
  id,
  name,
  value,
  onBlur,
  onChange,
  required,
}: CheckboxProps) {
  return (
    <div className={styles.option}>
      <label className={styles.customCheckbox}>
        <input
          type="checkbox"
          id={id}
          name={name}
          onBlur={onBlur}
          onChange={onChange}
          required={required}
          checked={value}
        />
        <span className={styles.checkmark}></span>
        {children}
      </label>
    </div>
  );
}
